using DigitalLibrary.Modules.Patrons.Application;
using DigitalLibrary.Modules.Patrons.Endpoints;
using DigitalLibrary.Modules.Patrons.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Patrons.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPatronsDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddApplication();
        services.AddEndpoints();

        return services;
    }
}
