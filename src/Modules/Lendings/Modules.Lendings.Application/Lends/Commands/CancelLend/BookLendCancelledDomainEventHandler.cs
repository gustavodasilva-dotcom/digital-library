using DigitalLibrary.Modules.Lendings.Domain.DomainEvents;
using DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;
using MassTransit;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.ConcludeLend;

internal sealed class BookLendCancelledDomainEventHandler
    : INotificationHandler<BookLendCancelledDomainEvent>
{
    private readonly IBus _bus;

    public BookLendCancelledDomainEventHandler(IBus bus)
    {
        _bus = bus;
    }

    public Task Handle(
        BookLendCancelledDomainEvent notification,
        CancellationToken cancellationToken)
    {
        return _bus.Publish(
            new LendFinishedIntegrationEvent(notification.BookId),
            cancellationToken);
    }
}
