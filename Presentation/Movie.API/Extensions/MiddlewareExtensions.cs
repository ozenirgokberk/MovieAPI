
using Movie.API.Middlewares;

namespace Movie.API.Extensions;

public static class MiddlewareExtensions
{
    public static IServiceCollection MiddlewareServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddExceptionHandler<GlobalErrorHandler>();
        return serviceCollection;
    }
}