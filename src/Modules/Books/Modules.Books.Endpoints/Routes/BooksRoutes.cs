namespace DigitalLibrary.Modules.Books.Endpoints.Routes;

internal sealed class BooksRoutes
{
    public const string Tag = "books";

    public const string Register = "api/books";

    public const string GetByAuthor = "api/books/{authorId:guid}";
}
