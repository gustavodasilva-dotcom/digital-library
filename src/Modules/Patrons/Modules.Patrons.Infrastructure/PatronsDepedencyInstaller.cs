using DigitalLibrary.Common.Infrastructure.Installers;
using DigitalLibrary.Modules.Patrons.Application;
using DigitalLibrary.Modules.Patrons.Endpoints;
using DigitalLibrary.Modules.Patrons.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Patrons.Infrastructure;

public class PatronsDepedencyInstaller : IDependencyInstaller
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
