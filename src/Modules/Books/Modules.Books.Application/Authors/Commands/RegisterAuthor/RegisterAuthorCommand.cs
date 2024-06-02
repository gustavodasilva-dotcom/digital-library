using DigitalLibrary.Common.Domain.Shared;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Authors.Commands.RegisterAuthor;

public sealed record RegisterAuthorCommand(string Name, string About)
    : IRequest<Result<Guid, Error>>;
