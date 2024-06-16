using DigitalLibrary.Modules.Lendings.Domain.DomainEvents;
using DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;
using MassTransit;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.RegisterLend;

internal sealed class BookLentDomainEventHandler
    : INotificationHandler<BookLentDomainEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public BookLentDomainEventHandler(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public Task Handle(
        BookLentDomainEvent notification,
        CancellationToken cancellationToken)
    {
        return _publishEndpoint.Publish(
            new BookLentIntegrationEvent(
                notification.LentId,
                notification.BookId,
                notification.StartDate,
                notification.EndDate,
                notification.CreatedDate),
            cancellationToken);
    }
}
