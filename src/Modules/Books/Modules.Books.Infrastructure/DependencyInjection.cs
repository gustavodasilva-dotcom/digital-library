using DigitalLibrary.Modules.Books.Application;
using DigitalLibrary.Modules.Books.Endpoints;
using DigitalLibrary.Modules.Books.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddBooksDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddApplication();
        services.AddEndpoints();

        return services;
    }
}
