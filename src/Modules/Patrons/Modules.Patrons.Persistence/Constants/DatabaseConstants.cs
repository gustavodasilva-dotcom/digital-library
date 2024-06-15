namespace DigitalLibrary.Modules.Patrons.Persistence.Constants;

internal sealed class DatabaseConstants
{
    public const string Schema = "patrons";

    public const string PatronsTable = "Patrons";

    public const string PatronLendsTable = "PatronLends";

    public const string PatronLendsCheckNotEmptyGuid = "CK_PatronLends_LendId_NotEmptyGuid";
}
