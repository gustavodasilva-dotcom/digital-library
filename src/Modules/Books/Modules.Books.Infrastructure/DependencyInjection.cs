using DigitalLibrary.Modules.Books.Application;
using DigitalLibrary.Modules.Books.Endpoints;
using DigitalLibrary.Modules.Books.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddBooks(this IServiceCollection services)
    {
        services.AddPersistence();
        services.AddApplication();
        services.AddEndpoints();

        return services;
    }
}
