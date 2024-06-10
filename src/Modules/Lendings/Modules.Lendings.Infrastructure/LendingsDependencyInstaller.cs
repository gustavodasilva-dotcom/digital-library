using DigitalLibrary.Common.Infrastructure.Installers;
using DigitalLibrary.Modules.Lendings.Application;
using DigitalLibrary.Modules.Lendings.Endpoints;
using DigitalLibrary.Modules.Lendings.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Lendings.Infrastructure;

public class LendingsDependencyInstaller : IDependencyInstaller
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
