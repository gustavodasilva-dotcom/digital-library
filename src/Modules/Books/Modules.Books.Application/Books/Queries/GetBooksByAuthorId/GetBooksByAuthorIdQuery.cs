using DigitalLibrary.Modules.Books.Application.Contracts;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Queries.GetBooksByAuthorId;

public sealed record GetBooksByAuthorIdQuery(Guid AuthorId)
    : IRequest<IEnumerable<BookContracts.BookResponse>>;
