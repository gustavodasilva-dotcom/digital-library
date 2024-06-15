namespace DigitalLibrary.Modules.Books.Application.Exceptions;

internal sealed class BookIsNotAvailableException(string bookTitle)
    : BaseApplicationException($"The book {bookTitle} is not available.");
