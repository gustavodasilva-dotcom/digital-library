using DigitalLibrary.Common.Domain.Abstractions;

namespace DigitalLibrary.Modules.Patrons.Domain.Entities;

public abstract class Entity : BaseEntity
{
    protected Entity() : base()
    {
    }

    protected Entity(Guid id) : base(id)
    {
    }
}
