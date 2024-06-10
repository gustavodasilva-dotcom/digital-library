using DigitalLibrary.Common.Domain.Extensions;
using DigitalLibrary.Common.Infrastructure.Installers;
using DigitalLibrary.Modules.Books.Application.Publishers.Commands.RegisterPublisher;
using DigitalLibrary.Modules.Books.Endpoints.Contracts;
using DigitalLibrary.Modules.Books.Endpoints.Routes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Modules.Books.Endpoints.Publishers;

public class RegisterPublisher : IEndpointInstaller
{
    public void InstallEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(PublishersRoutes.Register, async (
            [FromBody] RegisterPublisherRequest request,
            ISender sender) =>
        {
            var validationResult = request.ValidatePayload();

            if (validationResult.IsFailure)
            {
                return Results.BadRequest(validationResult.Error);
            }

            var command = new RegisterPublisherCommand(request.Name);

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Created(string.Empty, result.Value);
        })
        .WithTags(PublishersRoutes.Tag);
    }
}
