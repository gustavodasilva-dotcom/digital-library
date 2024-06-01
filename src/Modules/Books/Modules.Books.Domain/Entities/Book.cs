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
        bool isAvailable) : base(id)
    {
        Title = title;
        PublicationDate = publicationDate;
        TotalPages = totalPages;
        Isbn10 = isbn10;
        Isbn13 = isbn13;
        IsAvailable = isAvailable;
    }

    public string Title { get; private set; }

    public DateTime PublicationDate { get; private set; }

    public int TotalPages { get; private set; }

    public string Isbn10 { get; private set; }

    public string Isbn13 { get; private set; }

    public bool IsAvailable { get; private set; }

    public IReadOnlySet<BookLend> Lends => _lends;

    public static Book Create(
        string title,
        DateTime publicationDate,
        int totalPages,
        string isbn10,
        string isbn13)
    {
        var book = new Book(
            Guid.NewGuid(),
            title.Trim(),
            publicationDate,
            totalPages,
            isbn10.Trim(),
            isbn13.Trim(),
            isAvailable: true);

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
