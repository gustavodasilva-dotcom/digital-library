using DigitalLibrary.Common.Domain.Extensions;
using DigitalLibrary.Common.Infrastructure.Endpoints;
using DigitalLibrary.Modules.Books.Application.Authors.Commands.RegisterAuthor;
using DigitalLibrary.Modules.Books.Endpoints.Contracts;
using DigitalLibrary.Modules.Books.Endpoints.Routes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Modules.Books.Endpoints.Authors;

public class RegisterAuthor : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(AuthorsRoutes.Register, async (
            [FromBody] RegisterAuthorRequest request,
            ISender sender) => 
        {
            var validationResult = request.ValidatePayload();

            if (validationResult.IsFailure)
            {
                return Results.BadRequest(validationResult.Error);
            }

            var command = new RegisterAuthorCommand(
                request.Name,
                request.About);

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Created(string.Empty, result.Value);
        })
        .WithTags(AuthorsRoutes.Tag);
    }
}
