namespace Modules.Books.Persistence.Constants;

internal static class DatabaseConstants
{
    public const string BooksTable = "Books";

    public const string BooksTableCheckNotNegative = "CK_TotalPages_NotNegative";

    public const string BookLendsTable = "BookLends";

    public const string AuthorsTable = "Authors";
}
