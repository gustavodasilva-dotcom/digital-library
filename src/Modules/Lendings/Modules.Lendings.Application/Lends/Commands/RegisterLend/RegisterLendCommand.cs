using DigitalLibrary.Common.Domain.Shared;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.RegisterLend;

public sealed record RegisterLendCommand(
    Guid BookId,
    DateTime StartDate,
    DateTime EndDate) : IRequest<Result<Guid, Error>>;
