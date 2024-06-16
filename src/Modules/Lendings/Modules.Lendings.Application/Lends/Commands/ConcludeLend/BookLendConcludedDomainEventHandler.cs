using DigitalLibrary.Modules.Lendings.Domain.DomainEvents;
using DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;
using MassTransit;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.ConcludeLend;

internal sealed class BookLendConcludedDomainEventHandler
    : INotificationHandler<BookLendConcludedDomainEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public BookLendConcludedDomainEventHandler(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public Task Handle(
        BookLendConcludedDomainEvent notification,
        CancellationToken cancellationToken)
    {
        return _publishEndpoint.Publish(
            new LendFinishedIntegrationEvent(notification.BookId),
            cancellationToken);
    }
}
