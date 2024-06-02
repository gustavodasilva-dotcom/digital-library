namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class Book : Entity
{
    private readonly HashSet<BookLend> _lends = [];

    private Book()
    {
    }

    private Book(
        Guid id,
        string title,
        DateTime publicationDate,
        int totalPages,
        string isbn10,
        string isbn13,
        bool isAvailable,
        Guid authorId,
        DateTime createdDate) : base(id, createdDate)
    {
        Title = title;
        PublicationDate = publicationDate;
        TotalPages = totalPages;
        Isbn10 = isbn10;
        Isbn13 = isbn13;
        IsAvailable = isAvailable;
        AuthorId = authorId;
    }

    public string Title { get; private set; }

    public DateTime PublicationDate { get; private set; }

    public int TotalPages { get; private set; }

    public string Isbn10 { get; private set; }

    public string Isbn13 { get; private set; }

    public bool IsAvailable { get; private set; }

    public Guid AuthorId { get; private set; }

    public IReadOnlySet<BookLend> Lends => _lends;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Title;
        yield return PublicationDate;
        yield return TotalPages;
        yield return Isbn10;
        yield return Isbn13;
        yield return AuthorId;
    }

    public static Book Create(
        string title,
        DateTime publicationDate,
        int totalPages,
        string isbn10,
        string isbn13,
        Guid authorId)
    {
        var book = new Book(
            id: Guid.NewGuid(),
            title.Trim(),
            publicationDate,
            totalPages,
            isbn10.Trim(),
            isbn13.Trim(),
            isAvailable: true,
            authorId,
            createdDate: DateTime.Now);

        return book;
    }

    public void TurnBookIntoUnavailable()
    {
        IsAvailable = false;
    }

    public void AddLend(BookLend bookLend)
    {
        _lends.Add(bookLend);
    }
}
