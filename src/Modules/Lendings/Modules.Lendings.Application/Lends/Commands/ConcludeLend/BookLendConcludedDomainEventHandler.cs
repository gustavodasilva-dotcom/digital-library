using DigitalLibrary.Modules.Lendings.Domain.DomainEvents;
using DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;
using MassTransit;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.ConcludeLend;

internal sealed class BookLendConcludedDomainEventHandler
    : INotificationHandler<BookLendConcludedDomainEvent>
{
    private readonly IBus _bus;

    public BookLendConcludedDomainEventHandler(IBus bus)
    {
        _bus = bus;
    }

    public Task Handle(
        BookLendConcludedDomainEvent notification,
        CancellationToken cancellationToken)
    {
        return _bus.Publish(
            new LendConcludedIntegrationEvent(notification.BookId),
            cancellationToken);
    }
}
