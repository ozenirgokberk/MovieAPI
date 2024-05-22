using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Movie.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection service)
    {
        service.AddMediatR(typeof(ServiceRegistration));

    }
}