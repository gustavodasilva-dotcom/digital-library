using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Application.Contracts;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Commands.RegisterBook;

public sealed record RegisterBookCommand(
    string Title,
    DateTime PublicationDate,
    int TotalPages,
    string Edition,
    string Isbn10,
    string Isbn13,
    Guid PublisherId) : IRequest<Result<BookContracts.BookResponse, Error>>;
