namespace DigitalLibrary.Common.Domain.Abstractions;

public abstract class BaseEntity : IEquatable<BaseEntity>
{
    public abstract IEnumerable<object> GetAtomicValues();

    private bool ValuesAreEqual(BaseEntity other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public override bool Equals(object? obj)
    {
        return obj is BaseEntity other && ValuesAreEqual(other);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(
                default(int),
                HashCode.Combine);
    }

    public bool Equals(BaseEntity? other)
    {
        return other is not null && ValuesAreEqual(other);
    }
}
