using DigitalLibrary.Common.Domain.Abstractions;

namespace DigitalLibrary.Modules.Lendings.Domain.Entities;

public abstract class Entity : BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents;
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected Entity() : base()
    {
    }

    protected Entity(Guid id) : base(id)
    {
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
