using DigitalLibrary.Common.Domain.Abstractions;

namespace DigitalLibrary.Modules.Books.Domain.Entities;

public abstract class Entity : BaseEntity
{
    protected Entity()
    {
    }

    public Entity(Guid id, DateTime createdDate)
    {
        Id = id;
        CreatedDate = createdDate;
    }

    public Guid Id { get; private set; }

    public DateTime CreatedDate { get; private set; }
}
