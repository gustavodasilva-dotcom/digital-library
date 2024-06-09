using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Application.Contracts;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.RegisterLend;

public sealed record RegisterLendCommand(
    Guid BookId,
    DateTime StartDate,
    DateTime EndDate) : IRequest<Result<LendContracts.LendResponse, Error>>;
