using DigitalLibrary.Common.Infrastructure.Endpoints;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Lendings.Endpoints;

public static class DependencyInjection
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services.RegisterEndpoints(typeof(DependencyInjection).Assembly);

        return services;
    }
}
