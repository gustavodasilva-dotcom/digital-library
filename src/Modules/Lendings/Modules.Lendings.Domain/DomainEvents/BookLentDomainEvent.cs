using DigitalLibrary.Common.Domain.Abstractions;

namespace DigitalLibrary.Modules.Lendings.Domain.DomainEvents;

public sealed record BookLentDomainEvent(
    Guid LentId,
    Guid BookId,
    DateTime StartDate,
    DateTime EndDate,
    DateTime CreatedDate) : IDomainEvent;
