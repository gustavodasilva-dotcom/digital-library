using DigitalLibrary.Common.Domain.Extensions;
using DigitalLibrary.Common.Infrastructure.Endpoints;
using DigitalLibrary.Modules.Books.Application.Commands.AddAuthorToBook;
using DigitalLibrary.Modules.Books.Endpoints.Contracts;
using DigitalLibrary.Modules.Books.Endpoints.Routes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Modules.Books.Endpoints.Books;

public class AddAuthorToBook : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(BooksRoutes.AddAuthorToBook, async (
            [FromBody] AddAuthorToBookRequest request,
            ISender sender) =>
        {
            var validationResult = request.ValidatePayload();

            if (validationResult.IsFailure)
            {
                return Results.BadRequest(validationResult.Error);
            }

            var command = new AddAuthorToBookCommand(
                request.BookId,
                request.AuthorId,
                request.AuthorType);

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        })
        .WithTags(BooksRoutes.Tag);
    }
}
