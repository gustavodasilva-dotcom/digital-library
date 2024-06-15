
using DigitalLibrary.Common.Domain.Shared;

namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class Publisher : Entity
{
    private readonly HashSet<Book> _books = [];

    private Publisher() : base()
    {
    }

    private Publisher(Guid id, string name, DateTime createdDate)
        : base(id, createdDate)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public IReadOnlySet<Book> Books => _books;

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

    public Result<Book, Error> AddBook(Book book)
    {
        if (_books.Any(b => b.Equals(book)))
        {
            return new Error(
                "AddBook.PublisherAlreadyHasBook",
                "It's not possible to add repetead books to a publisher");
        }

        _books.Add(book);

        return book;
    }
}
