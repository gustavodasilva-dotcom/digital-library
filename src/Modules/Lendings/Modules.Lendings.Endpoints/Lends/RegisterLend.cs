using DigitalLibrary.Common.Domain.Extensions;
using DigitalLibrary.Common.Infrastructure.Endpoints;
using DigitalLibrary.Modules.Lendings.Application.Lends.Commands.RegisterLend;
using DigitalLibrary.Modules.Lendings.Endpoints.Contracts;
using DigitalLibrary.Modules.Lendings.Endpoints.Routes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Modules.Lendings.Endpoints.Lends;

public class RegisterLend : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(LendingsRoutes.Register, async (
            [FromBody] RegisterLendRequest request,
            ISender sender) =>
        {
            var validationResult = request.ValidatePayload();

            if (validationResult.IsFailure)
            {
                return Results.BadRequest(validationResult.Error);
            }

            var command = new RegisterLendCommand(
                request.BookId,
                request.StartDate,
                request.EndDate);

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Created(string.Empty, result.Value);
        })
        .WithTags(LendingsRoutes.Tag);
    }
}
