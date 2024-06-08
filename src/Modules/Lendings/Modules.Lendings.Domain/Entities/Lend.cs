using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Domain.DomainEvents;
using DigitalLibrary.Modules.Lendings.Domain.Enumerations;
using RandomString4Net;

namespace DigitalLibrary.Modules.Lendings.Domain.Entities;

public class Lend : Entity
{
    private Lend()
    {
    }

    public Lend(
        Guid id,
        string code,
        LendStatuses status,
        Guid bookId,
        DateTime startDate,
        DateTime endDate,
        DateTime createdDate) : base(id)
    {
        Code = code;
        Status = status;
        BookId = bookId;
        StartDate = startDate;
        EndDate = endDate;
        CreatedDate = createdDate;
    }

    public string Code { get; private set; }

    public LendStatuses Status { get; private set; }

    public Guid BookId { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public DateTime? ConcludedDate { get; private set; }

    public DateTime? CancelledDate { get; private set; }

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

    private void CreateBookLendConcludedDomainEvent()
    {
        RaiseDomainEvent(new BookLendConcludedDomainEvent(BookId));
    }

    public static Lend Create(Guid bookId, DateTime startDate, DateTime endDate)
    {
        var lend = new Lend(
            Guid.NewGuid(),
            code: RandomString.GetString(Types.ALPHANUMERIC_UPPERCASE, 10),
            status: LendStatuses.Open,
            bookId,
            startDate,
            endDate,
            createdDate: DateTime.Now);

        lend.CreateBookLentDomainEvent();

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
}
