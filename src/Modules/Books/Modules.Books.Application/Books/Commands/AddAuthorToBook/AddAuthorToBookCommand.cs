using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Enumerations;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Commands.AddAuthorToBook;

public sealed record AddAuthorToBookCommand(
    Guid BookId,
    Guid AuthorId,
    AuthorTypes AuthorType) : IRequest<Result<BookContracts.BookResponse, Error>>;
