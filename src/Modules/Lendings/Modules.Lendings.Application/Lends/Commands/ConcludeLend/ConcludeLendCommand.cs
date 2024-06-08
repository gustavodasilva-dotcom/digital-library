using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Application.Contracts;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.ConcludeLend;

public sealed record ConcludeLendCommand(string Code)
    : IRequest<Result<LendResponse, Error>>;
