namespace DigitalLibrary.Modules.Patrons.Application.Exceptions;

internal abstract class BaseApplicationException(string message)
    : Exception(message);
