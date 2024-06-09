using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Application.Contracts;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.CancelLend;

public sealed record CancelLendCommand(string Code)
    : IRequest<Result<LendContracts.LendResponse, Error>>;
