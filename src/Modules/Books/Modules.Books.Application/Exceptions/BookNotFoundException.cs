namespace DigitalLibrary.Modules.Books.Application.Exceptions;

internal sealed class BookNotFoundException(Guid bookId)
    : BaseApplicationException($"No book was found with the id {bookId}.");
