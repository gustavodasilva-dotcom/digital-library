
using RandomString4Net;

namespace DigitalLibrary.Modules.Patrons.Domain.Entities;

public class Patron : Entity
{
    private Patron()
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
}
