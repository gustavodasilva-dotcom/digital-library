
namespace DigitalLibrary.Modules.Patrons.Domain.Entities;

public class PatronLend : Entity
{
    private PatronLend() : base()
    {
    }

    private PatronLend(
        Guid id,
        Guid patronId,
        Guid lendId,
        DateTime startLendDate,
        DateTime endLendDate,
        DateTime createdDate) : base(id)
    {
        PatronId = patronId;
        LendId = lendId;
        StartLendDate = startLendDate;
        EndLendDate = endLendDate;
        CreatedDate = createdDate;
    }

    public Guid PatronId { get; private set; }

    public Guid LendId { get; private set; }

    public DateTime StartLendDate { get; private set; }

    public DateTime EndLendDate { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return PatronId;
        yield return LendId;
        yield return StartLendDate;
        yield return EndLendDate;
        yield return CreatedDate;
    }

    public static PatronLend Create(
        Guid patronId,
        Guid lendId,
        DateTime startLendDate,
        DateTime endLendDate,
        DateTime createdDate)
    {
        var patronLend = new PatronLend(
            id: Guid.NewGuid(),
            patronId,
            lendId,
            startLendDate,
            endLendDate,
            createdDate);

        return patronLend;
    }
}
