using DigitalLibrary.Common.Domain.Shared;

namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class Book : Entity
{
    private readonly Publisher _publisher;

    private readonly HashSet<BookAuthor> _authors = [];

    private readonly HashSet<BookLend> _lends = [];

    private Book()
    {
    }

    private Book(
        Guid id,
        string title,
        DateTime publicationDate,
        int totalPages,
        string edition,
        string isbn10,
        string isbn13,
        bool isAvailable,
        Guid publisherId,
        DateTime createdDate) : base(id, createdDate)
    {
        Title = title;
        PublicationDate = publicationDate;
        TotalPages = totalPages;
        Edition = edition;
        Isbn10 = isbn10;
        Isbn13 = isbn13;
        IsAvailable = isAvailable;
        PublisherId = publisherId;
    }

    public string Title { get; private set; }

    public DateTime PublicationDate { get; private set; }

    public int TotalPages { get; private set; }

    public string Edition { get; private set; }

    public string Isbn10 { get; private set; }

    public string Isbn13 { get; private set; }

    public bool IsAvailable { get; private set; }

    public Guid PublisherId { get; private set; }

    public virtual Publisher Publisher => _publisher;

    public virtual IReadOnlySet<BookAuthor> Authors => _authors;

    public virtual IReadOnlySet<BookLend> Lends => _lends;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Title;
        yield return PublicationDate;
        yield return TotalPages;
        yield return Edition;
        yield return Isbn10;
        yield return Isbn13;
    }

    public static Book Create(
        string title,
        DateTime publicationDate,
        int totalPages,
        string edition,
        string isbn10,
        string isbn13,
        Guid publisherId)
    {
        var book = new Book(
            id: Guid.NewGuid(),
            title.Trim(),
            publicationDate,
            totalPages,
            edition.Trim(),
            isbn10.Trim(),
            isbn13.Trim(),
            isAvailable: true,
            publisherId,
            createdDate: DateTime.Now);

        return book;
    }

    public void TurnBookIntoAvailable()
    {
        IsAvailable = true;
    }

    public void TurnBookIntoUnavailable()
    {
        IsAvailable = false;
    }

    public Result<BookAuthor, Error> AddBookAuthor(BookAuthor bookAuthor)
    {
        if (_authors.Any(a => a.Equals(bookAuthor)))
        {
            return new Error(
                "AddAuthorToBook.BookAlreadyHasAuthor",
                "It's not possible to add repetead authors to a book");
        }

        _authors.Add(bookAuthor);

        return bookAuthor;
    }

    public Result<Book, Error> AddLend(BookLend bookLend)
    {
        if (_lends.Any(l => l.Equals(bookLend)))
        {
            return new Error(
                "AddLend.BookAlreadyHasLend",
                "It's not possible to add repetead lends to a book");
        }

        _lends.Add(bookLend);

        return this;
    }
}
