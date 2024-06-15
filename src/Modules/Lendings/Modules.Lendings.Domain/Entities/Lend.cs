using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Domain.DomainEvents;
using DigitalLibrary.Modules.Lendings.Domain.Enumerations;
using RandomString4Net;

namespace DigitalLibrary.Modules.Lendings.Domain.Entities;

public class Lend : Entity
{
    private Lend() : base()
    {
    }

    public Lend(
        Guid id,
        string code,
        LendStatuses status,
        Guid bookId,
        Guid patronId,
        DateTime startDate,
        DateTime endDate,
        DateTime createdDate) : base(id)
    {
        Code = code;
        Status = status;
        BookId = bookId;
        PatronId = patronId;
        StartDate = startDate;
        EndDate = endDate;
        CreatedDate = createdDate;
    }

    public string Code { get; private set; }

    public LendStatuses Status { get; private set; }

    public Guid BookId { get; private set; }

    public Guid PatronId { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public DateTime? ConcludedDate { get; private set; }

    public DateTime? CancelledDate { get; private set; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return Status;
        yield return BookId;
        yield return PatronId;
        yield return StartDate;
        yield return EndDate;
    }

    private void CreateBookLentDomainEvent()
    {
        RaiseDomainEvent(
            new BookLentDomainEvent(
                LentId: Id,
                BookId,
                StartDate,
                EndDate,
                CreatedDate));
    }

    public void CreatePatronLentDomainEvent()
    {
        RaiseDomainEvent(
            new PatronLentDomainEvent(
                LentId: Id,
                PatronId,
                StartDate,
                EndDate,
                CreatedDate));
    }

    private void CreateBookLendConcludedDomainEvent()
    {
        RaiseDomainEvent(new BookLendConcludedDomainEvent(BookId));
    }

    private void CreateBookLendCancelledDomainEvent()
    {
        RaiseDomainEvent(new BookLendCancelledDomainEvent(BookId));
    }

    public static Lend Create(
        Guid bookId,
        Guid patronId,
        DateTime startDate,
        DateTime endDate)
    {
        string code = RandomString.GetString(Types.ALPHANUMERIC_UPPERCASE, 10);

        var lend = new Lend(
            id: Guid.NewGuid(),
            code,
            status: LendStatuses.Open,
            bookId,
            patronId,
            startDate,
            endDate,
            createdDate: DateTime.Now);

        lend.CreateBookLentDomainEvent();
        lend.CreatePatronLentDomainEvent();

        return lend;
    }

    public Result<Lend, Error> Conclude()
    {
        if (Status == LendStatuses.Concluded || Status == LendStatuses.Cancelled)
        {
            return new Error(
                "ConcludeLend.ConcludedOrCancelled",
                "The lend is concluded or cancelled");
        }

        Status = LendStatuses.Concluded;
        ConcludedDate = DateTime.Now;

        CreateBookLendConcludedDomainEvent();

        return this;
    }

    public Result<Lend, Error> Cancel()
    {
        if (Status == LendStatuses.Concluded || Status == LendStatuses.Cancelled)
        {
            return new Error(
                "ConcludeLend.ConcludedOrCancelled",
                "The lend is concluded or cancelled");
        }

        if (Status != LendStatuses.OnQueue)
        {
            CreateBookLendCancelledDomainEvent();
        }

        Status = LendStatuses.Cancelled;
        CancelledDate = DateTime.Now;

        return this;
    }
}
