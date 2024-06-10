using DigitalLibrary.Common.Infrastructure.Installers;
using DigitalLibrary.Modules.Lendings.Application.Lends.Commands.ConcludeLend;
using DigitalLibrary.Modules.Lendings.Endpoints.Routes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Modules.Lendings.Endpoints.Lends;

public class ConcludeLend : IEndpointInstaller
{
    public void InstallEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(LendingsRoutes.Conclude, async (
            string code,
            ISender sender) =>
        {
            var command = new ConcludeLendCommand(code);

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        })
        .WithTags(LendingsRoutes.Tag);
    }
}
