using DigitalLibrary.Modules.Lendings.Domain.DomainEvents;
using DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;
using MassTransit;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.RegisterLend;

internal sealed class PatronLentDomainEventHandler
    : INotificationHandler<PatronLentDomainEvent>
{
    private readonly IBus _bus;

    public PatronLentDomainEventHandler(IBus bus)
    {
        _bus = bus;
    }

    public Task Handle(
        PatronLentDomainEvent notification,
        CancellationToken cancellationToken)
    {
        return _bus.Publish(
            new PatronLentIntegrationEvent(
                notification.PatronId,
                notification.LentId,
                notification.StartDate,
                notification.EndDate,
                notification.CreatedDate),
            cancellationToken);
    }
}
