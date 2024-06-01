using DigitalLibrary.Modules.Lendings.Application;
using DigitalLibrary.Modules.Lendings.Endpoints;
using DigitalLibrary.Modules.Lendings.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Lendings.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddLending(this IServiceCollection services)
    {
        services.AddPersistence();
        services.AddApplication();
        services.AddEndpoints();

        return services;
    }
}
