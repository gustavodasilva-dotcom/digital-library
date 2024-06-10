using DigitalLibrary.Common.Domain.Extensions;
using DigitalLibrary.Common.Infrastructure.Endpoints;
using DigitalLibrary.Modules.Books.Application.Commands.RegisterBook;
using DigitalLibrary.Modules.Books.Endpoints.Contracts;
using DigitalLibrary.Modules.Books.Endpoints.Routes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Modules.Books.Endpoints.Books;

public class RegisterBook : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(BooksRoutes.Register, async (
            [FromBody] RegisterBookRequest request,
            ISender sender) =>
        {
            var validationResult = request.ValidatePayload();

            if (validationResult.IsFailure)
            {
                return Results.BadRequest(validationResult.Error);
            }

            var command = new RegisterBookCommand(
                request.Title,
                request.PublicationDate,
                request.TotalPages,
                request.Edition,
                request.Isbn10,
                request.Isbn13,
                request.PublisherId);

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Created(string.Empty, result.Value);
        })
        .WithTags(BooksRoutes.Tag);
    }
}
