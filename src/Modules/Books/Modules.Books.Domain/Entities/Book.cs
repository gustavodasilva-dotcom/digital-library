using DigitalLibrary.Common.Domain.Shared;

namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class Book : Entity
{
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
        DateTime createdDate) : base(id, createdDate)
    {
        Title = title;
        PublicationDate = publicationDate;
        TotalPages = totalPages;
        Edition = edition;
        Isbn10 = isbn10;
        Isbn13 = isbn13;
        IsAvailable = isAvailable;
    }

    public string Title { get; private set; }

    public DateTime PublicationDate { get; private set; }

    public int TotalPages { get; private set; }

    public string Edition { get; private set; }

    public string Isbn10 { get; private set; }

    public string Isbn13 { get; private set; }

    public bool IsAvailable { get; private set; }

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
        string isbn13)
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

    public void AddLend(BookLend bookLend)
    {
        _lends.Add(bookLend);
    }
}
