namespace DigitalLibrary.Modules.Books.Application.Exceptions;

public abstract class BaseApplicationException(string message)
    : Exception(message)
{
}
