using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.Domain.Entities;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.RegisterLend;

internal sealed class RegisterLendCommandHandler
    : IRequestHandler<RegisterLendCommand, Result<Guid, Error>>
{
    private readonly ILendRepository _lendRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterLendCommandHandler(ILendRepository lendRepository, IUnitOfWork unitOfWork)
    {
        _lendRepository = lendRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, Error>> Handle(
        RegisterLendCommand request,
        CancellationToken cancellationToken)
    {
        if (_lendRepository.Get(l => l.BookId == request.BookId && l.EndDate > DateTime.Now) != null)
        {
            return new Error("RegisterLend.BookIsLent", "This book has already been lent");
        }

        var lend = Lend.Create(request.BookId, request.StartDate, request.EndDate);

        _lendRepository.Add(lend);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return lend.Id;
    }
}
