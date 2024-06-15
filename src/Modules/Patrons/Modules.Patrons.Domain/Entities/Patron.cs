
using DigitalLibrary.Common.Domain.Shared;
using RandomString4Net;

namespace DigitalLibrary.Modules.Patrons.Domain.Entities;

public class Patron : Entity
{
    private readonly HashSet<PatronLend> _lends = [];

    private Patron() : base()
    {
    }

    private Patron(
        Guid id,
        long registrationNumber,
        string firstName,
        string? middleName,
        string lastName,
        DateTime birthday) : base(id)
    {
        RegistrationNumber = registrationNumber;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Birthday = birthday;
    }

    public long RegistrationNumber { get; private set; }

    public string FirstName { get; private set; }

    public string? MiddleName { get; private set; }

    public string LastName { get; private set; }

    public DateTime Birthday { get; private set; }

    public IReadOnlySet<PatronLend> Lends => _lends;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return RegistrationNumber;
        yield return FirstName;
        yield return MiddleName ?? string.Empty;
        yield return LastName;
        yield return Birthday;
    }

    public static Patron Create(
        string firstName,
        string? middleName,
        string lastName,
        DateTime birthday)
    {
        var registrationNumber = long.Parse(RandomString.GetString(Types.NUMBERS, 10));

        var patron = new Patron(
            id: Guid.NewGuid(),
            registrationNumber,
            firstName.Trim(),
            middleName?.Trim(),
            lastName.Trim(),
            birthday);

        return patron;
    }

    public Result<Patron, Error> AddLend(PatronLend patronLend)
    {
        if (_lends.Any(l => l.Equals(patronLend)))
        {
            return new Error(
                "AddLend.PatronAlreadyHasLend",
                "It's not possible to add repetead lends to a patron");
        }

        _lends.Add(patronLend);

        return this;
    }
}
