using DigitalLibrary.Modules.Lendings.Domain.DomainEvents;
using DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;
using MassTransit;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.RegisterLend;

internal sealed class PatronLentDomainEventHandler
    : INotificationHandler<PatronLentDomainEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public PatronLentDomainEventHandler(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public Task Handle(
        PatronLentDomainEvent notification,
        CancellationToken cancellationToken)
    {
        return _publishEndpoint.Publish(
            new PatronLentIntegrationEvent(
                notification.PatronId,
                notification.LentId,
                notification.StartDate,
                notification.EndDate,
                notification.CreatedDate),
            cancellationToken);
    }
}
