using DigitalLibrary.Common.Infrastructure.Installers;
using DigitalLibrary.Modules.Lendings.Application.Lends.Commands.CancelLend;
using DigitalLibrary.Modules.Lendings.Endpoints.Routes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Modules.Lendings.Endpoints.Lends;

public class CancelLend : IEndpointInstaller
{
    public void InstallEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(LendingsRoutes.Cancel, async (
            string code,
            ISender sender) =>
        {
            var command = new CancelLendCommand(code);

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
