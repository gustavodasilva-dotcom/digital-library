namespace DigitalLibrary.Modules.Books.Application.Exceptions;

internal abstract class BaseApplicationException(string message)
    : Exception(message);
