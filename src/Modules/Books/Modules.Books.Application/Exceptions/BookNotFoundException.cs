namespace DigitalLibrary.Modules.Books.Application.Exceptions;

public class BookNotFoundException(Guid bookId)
    : BaseApplicationException($"No book was found with the id {bookId}.");
