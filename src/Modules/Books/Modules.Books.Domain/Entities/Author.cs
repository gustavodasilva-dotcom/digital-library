namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class Author : Entity
{
    private readonly HashSet<BookAuthor> _books = [];

    private Author()
    {
    }

    private Author(
        Guid id,
        string name,
        string about,
        DateTime createdDate) : base(id, createdDate)
    {
        Name = name;
        About = about;
    }

    public string Name { get; private set; }

    public string About { get; private set; }

    public virtual IReadOnlySet<BookAuthor> Books => _books;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return About; 
    }

    public static Author Create(string name, string about)
    {
        var author = new Author(
            id: Guid.NewGuid(),
            name.Trim(),
            about.Trim(),
            createdDate: DateTime.Now);

        return author;
    }
}
