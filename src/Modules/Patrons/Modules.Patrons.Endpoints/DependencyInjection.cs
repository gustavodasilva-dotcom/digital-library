using DigitalLibrary.Common.Infrastructure.Installers;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Patrons.Endpoints;

public static class DependencyInjection
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services.InstallEndpoints(typeof(DependencyInjection).Assembly);

        return services;
    }
}
