using DigitalLibrary.Common.Domain.Extensions;
using DigitalLibrary.Common.Infrastructure.Endpoints;
using DigitalLibrary.Modules.Patrons.Application;
using DigitalLibrary.Modules.Patrons.Endpoints.Contracts;
using DigitalLibrary.Modules.Patrons.Endpoints.Routes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Modules.Patrons.Endpoints.Patrons;

public class RegisterPatron : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(PatronsRoutes.Register, async (
            [FromBody] RegisterPatronRequest request,
            ISender sender) =>
        {
            var validationResult = request.ValidatePayload();

            if (validationResult.IsFailure)
            {
                return Results.BadRequest(validationResult.Error);
            }

            var command = new RegisterPatronCommand(
                request.FirstName,
                request.MiddleName,
                request.LastName,
                request.Birthday);

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Created(string.Empty, result.Value);
        })
        .WithTags(PatronsRoutes.Tag);
    }
}
