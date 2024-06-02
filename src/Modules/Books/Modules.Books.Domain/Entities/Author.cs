using DigitalLibrary.Common.Domain.Shared;

namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class Author : Entity
{
    private readonly HashSet<Book> _books = [];

    private Author()
    {
    }

    private Author(Guid id, string name, string about, DateTime createdDate)
        : base(id, createdDate)
    {
        Name = name;
        About = about;
    }

    public string Name { get; private set; }

    public string About { get; private set; }

    public IReadOnlySet<Book> Books => _books;

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

    public Result<Book, Error> AddBook(Book book)
    {
        if (_books.Any(b => b.Equals(book)))
        {
            return new Error(
                "RegisterBook.AuthorAlreadyHasBook",
                $"The author already has the book {book.Title} registered");
        }

        _books.Add(book);

        return book;
    }
}
