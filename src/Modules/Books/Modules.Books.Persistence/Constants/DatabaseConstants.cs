namespace Modules.Books.Persistence.Constants;

internal static class DatabaseConstants
{
    public const string Schema = "books";

    public const string BooksTable = "Books";
    
    public const string AuthorsTable = "Authors";

    public const string BookAuthorsTable = "BookAuthors";
    
    public const string BookLendsTable = "BookLends";

    public const string BooksTableCheckNotNegative = "CK_TotalPages_NotNegative";
}
