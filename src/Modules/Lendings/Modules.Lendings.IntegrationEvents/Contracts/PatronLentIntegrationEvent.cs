namespace DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;

public sealed record PatronLentIntegrationEvent(
    Guid PatronId,
    Guid LendId,
    DateTime StartDate,
    DateTime EndDate,
    DateTime CreatedDate);
