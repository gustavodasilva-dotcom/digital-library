using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Common.Infrastructure.Installers;

public interface IDependencyInstaller
{
    void InstallService(
        IServiceCollection services,
        IConfiguration configuration);
}
