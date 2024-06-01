using DigitalLibrary.Modules.Lendings.Domain.DomainEvents;

namespace DigitalLibrary.Modules.Lendings.Domain.Entities;

public class Lend : Entity
{
    private Lend()
    {
    }

    public Lend(
        Guid id,
        Guid bookId,
        DateTime startDate,
        DateTime endDate,
        DateTime createdDate) : base(id)
    {
        BookId = bookId;
        StartDate = startDate;
        EndDate = endDate;
        CreatedDate = createdDate;
    }

    public Guid BookId { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public DateTime CreatedDate { get; private set; }

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

    public static Lend Create(Guid bookId, DateTime startDate, DateTime endDate)
    {
        var lend = new Lend(
            Guid.NewGuid(),
            bookId,
            startDate,
            endDate,
            DateTime.Now);

        lend.CreateBookLentDomainEvent();

        return lend;
    }
}
