using DigitalLibrary.Common.Domain.Abstractions;

namespace DigitalLibrary.Modules.Books.Domain.Entities;

public abstract class Entity : BaseEntity
{
    protected Entity() : base()
    {
    }

    public Entity(Guid id, DateTime createdDate)
        : base(id)
    {
        CreatedDate = createdDate;
    }

    public DateTime CreatedDate { get; private set; }
}
