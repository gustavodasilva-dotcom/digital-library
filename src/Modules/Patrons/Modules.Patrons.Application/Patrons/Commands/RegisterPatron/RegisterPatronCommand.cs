using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Patrons.Application.Contracts;
using MediatR;

namespace DigitalLibrary.Modules.Patrons.Application;

public sealed record RegisterPatronCommand(
    string FirstName,
    string? MiddleName,
    string LastName,
    DateTime Birthday) : IRequest<Result<PatronContracts.PatronResponse, Error>>;
