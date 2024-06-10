using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Common.Infrastructure.Installers;

public interface IEndpointInstaller
{
    void InstallEndpoint(IEndpointRouteBuilder app);
}
