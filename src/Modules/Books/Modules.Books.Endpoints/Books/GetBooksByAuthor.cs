using DigitalLibrary.Common.Infrastructure.Endpoints;
using DigitalLibrary.Modules.Books.Application.Queries.GetBooksByAuthorId;
using DigitalLibrary.Modules.Books.Endpoints.Routes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Modules.Books.Endpoints;

public class GetBooksByAuthor : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(BooksRoutes.GetByAuthor, async (
            Guid authorId,
            ISender sender) =>
        {
            var query = new GetBooksByAuthorIdQuery(authorId);

            var books = await sender.Send(query);

            if (!books.Any())
            {
                return Results.NoContent();
            }

            return Results.Ok(books);
        })
        .WithTags(BooksRoutes.Tag);
    }
}
