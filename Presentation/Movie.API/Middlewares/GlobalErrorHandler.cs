using System.Diagnostics;
using System.Transactions;
using Microsoft.AspNetCore.Diagnostics;
using Movie.Application.DTOs;

namespace Movie.API.Middlewares;

public class GlobalErrorHandler : IExceptionHandler
{
    private readonly ILogger<GlobalErrorHandler> _logger;

    public GlobalErrorHandler(ILogger<GlobalErrorHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        var traceId = Activity.Current.Id ?? httpContext.TraceIdentifier;
        _logger.LogError(traceId,exception, $"Could not response any successfull from {Environment.MachineName}. TraceId : {traceId}");
        
        var (statusCode, title, detail)  = MapException(exception);
        
        // await Results.Problem(
        //     title: title, 
        //     statusCode:statusCode, 
        //     extensions: new Dictionary<string, object?>
        //         {
        //             {"traceId",traceId}
        //         }).ExecuteAsync(httpContext);

        var model = new ErrorResponse()
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
            Type = exception.GetType().Name
        };

        await httpContext.Response.WriteAsJsonAsync(model, cancellationToken);
        return true;
    }
    
    


    private static (int statusCode, string title, string detail) MapException(Exception exception)
    {
        return (exception switch
        {
            ArgumentOutOfRangeException => (StatusCodes.Status400BadRequest, exception.Message, exception.StackTrace),
            ApplicationException => (StatusCodes.Status409Conflict, exception.Message, exception.StackTrace),
            TransactionException => (StatusCodes.Status409Conflict, exception.Message, exception.StackTrace),
            _ => (StatusCodes.Status500InternalServerError, exception.Message, exception.StackTrace),
            

        })!;
    }

}