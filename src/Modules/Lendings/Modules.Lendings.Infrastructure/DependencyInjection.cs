using DigitalLibrary.Modules.Lendings.Application;
using DigitalLibrary.Modules.Lendings.Endpoints;
using DigitalLibrary.Modules.Lendings.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Lendings.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddLendingsDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddApplication();
        services.AddEndpoints();

        return services;
    }
}
