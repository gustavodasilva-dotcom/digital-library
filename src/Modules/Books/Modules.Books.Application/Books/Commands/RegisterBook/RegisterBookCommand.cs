using DigitalLibrary.Common.Domain.Shared;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Commands.RegisterBook;

public sealed record RegisterBookCommand(
    string Title,
    DateTime PublicationDate,
    int TotalPages,
    string Edition,
    string Isbn10,
    string Isbn13) : IRequest<Result<Guid, Error>>;
