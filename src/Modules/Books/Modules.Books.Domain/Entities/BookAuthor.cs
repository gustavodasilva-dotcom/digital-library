
using DigitalLibrary.Modules.Books.Domain.Enumerations;

namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class BookAuthor : Entity
{
    private BookAuthor()
    {
    }

    private BookAuthor(
        Guid id,
        Guid bookId,
        Guid authorId,
        AuthorTypes authorType,
        DateTime createdDate) : base(id, createdDate)
    {
        BookId = bookId;
        AuthorId = authorId;
        AuthorType = authorType;
    }

    public Guid BookId { get; private set; }

    public Guid AuthorId { get; private set; }

    public AuthorTypes AuthorType { get; private set; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return BookId;
        yield return AuthorId;
        yield return AuthorType;
    }

    public static BookAuthor Create(
        Guid bookId,
        Guid authorId,
        AuthorTypes authorType)
    {
        var bookAuthor = new BookAuthor(
            id: Guid.NewGuid(),
            bookId,
            authorId,
            authorType,
            createdDate: DateTime.Now);

        return bookAuthor;
    }
}
