using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Application.Contracts;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.RegisterLend;

public sealed record RegisterLendCommand(
    Guid BookId,
    Guid PatronId,
    DateTime StartDate,
    DateTime EndDate) : IRequest<Result<LendContracts.LendResponse, Error>>;
