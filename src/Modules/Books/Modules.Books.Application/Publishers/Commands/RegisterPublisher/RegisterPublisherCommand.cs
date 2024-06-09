using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Application.Contracts;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Publishers.Commands.RegisterPublisher;

public sealed record RegisterPublisherCommand(string Name)
    : IRequest<Result<PublisherContracts.PublisherResponse, Error>>;
