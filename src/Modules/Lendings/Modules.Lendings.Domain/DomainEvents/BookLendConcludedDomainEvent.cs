using DigitalLibrary.Common.Domain.Abstractions;

namespace DigitalLibrary.Modules.Lendings.Domain.DomainEvents;

public sealed record BookLendConcludedDomainEvent(Guid BookId) : IDomainEvent;
