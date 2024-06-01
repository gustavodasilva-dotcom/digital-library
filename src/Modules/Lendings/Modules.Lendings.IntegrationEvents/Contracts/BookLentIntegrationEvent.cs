namespace DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;

public sealed record BookLentIntegrationEvent(
    Guid LendId,
    Guid BookId,
    DateTime StartDate,
    DateTime EndDate,
    DateTime CreatedDate);
