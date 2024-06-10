using DigitalLibrary.Common.Infrastructure.Installers;
using DigitalLibrary.Modules.Books.Application;
using DigitalLibrary.Modules.Books.Endpoints;
using DigitalLibrary.Modules.Books.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Infrastructure;

public class BooksDependencyInstaller : IDependencyInstaller
{
    public void InstallService(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddPersistence(configuration)
            .AddApplication()
            .AddEndpoints();
    }
}
