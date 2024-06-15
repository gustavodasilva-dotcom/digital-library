namespace DigitalLibrary.Modules.Patrons.Application.Exceptions;

internal sealed class PatronNotFoundException(Guid patronId)
    : BaseApplicationException($"No patron was found with the id {patronId}.");
