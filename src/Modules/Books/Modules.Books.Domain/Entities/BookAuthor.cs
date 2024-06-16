
using DigitalLibrary.Modules.Books.Domain.Enumerations;

namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class BookAuthor : Entity
{
    private readonly Book _book;

    private readonly Author _author;

    private BookAuthor()
    {
    }

    private BookAuthor(
        Guid id,
        AuthorTypes authorType,
        Guid bookId,
        Guid authorId,
        DateTime createdDate) : base(id, createdDate)
    {
        AuthorType = authorType;
        BookId = bookId;
        AuthorId = authorId;
    }
    
    public AuthorTypes AuthorType { get; private set; }

    public Guid BookId { get; private set; }

    public Guid AuthorId { get; private set; }

    public virtual Book Book => _book;

    public virtual Author Author => _author;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return AuthorType;
        yield return BookId;
        yield return AuthorId;
    }

    public static BookAuthor Create(
        AuthorTypes authorType,
        Guid bookId,
        Guid authorId)
    {
        var bookAuthor = new BookAuthor(
            id: Guid.NewGuid(),
            authorType,
            bookId,
            authorId,
            createdDate: DateTime.Now);

        return bookAuthor;
    }
}
