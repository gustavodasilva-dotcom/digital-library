namespace DigitalLibrary.Modules.Books.Domain.Entities;

public class BookLend : Entity
{
    private BookLend()
    {
    }

    private BookLend(
        Guid id,
        Guid bookId,
        Guid lendId,
        DateTime startLendDate,
        DateTime endLendDate,
        DateTime lendDate,
        DateTime createdDate) : base(id, createdDate)
    {
        BookId = bookId;
        LendId = lendId;
        StartLendDate = startLendDate;
        EndLendDate = endLendDate;
        LendDate = lendDate;
    }

    public Guid BookId { get; private set; }

    public Guid LendId { get; private set; }

    public DateTime StartLendDate { get; private set; }

    public DateTime EndLendDate { get; private set; } 

    public DateTime LendDate { get; private set; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return BookId;
        yield return LendId;
        yield return StartLendDate;
        yield return EndLendDate;
        yield return LendDate;
    }

    public static BookLend Create(
        Guid bookId,
        Guid lendId,
        DateTime startLendDate,
        DateTime endLendDate,
        DateTime lendDate)
    {
        var bookLend = new BookLend(
            id: Guid.NewGuid(),
            bookId,
            lendId,
            startLendDate,
            endLendDate,
            lendDate,
            createdDate: DateTime.Now);

        return bookLend;
    }
}
