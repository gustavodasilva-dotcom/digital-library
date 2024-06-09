
namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class Publisher : Entity
{
    private Publisher()
    {
    }

    private Publisher(Guid id, string name, DateTime createdDate)
        : base(id, createdDate)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
    }

    public static Publisher Create(string name)
    {
        var publisher = new Publisher(
            id: Guid.NewGuid(),
            name.Trim(),
            createdDate: DateTime.Now);

        return publisher;
    }
}
