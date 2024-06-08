namespace DigitalLibrary.Modules.Books.Application.Exceptions;

public class BookIsNotAvailableException(string bookTitle)
    : BaseApplicationException($"The book {bookTitle} is not available.");
