using AutoMapper;
using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Application.Contracts;
using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.CancelLend;

internal sealed class CancelLendCommandHandler
    : IRequestHandler<CancelLendCommand, Result<LendResponse, Error>>
{
    private readonly ILendRepository _lendRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CancelLendCommandHandler(
        ILendRepository lendRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _lendRepository = lendRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<LendResponse, Error>> Handle(
        CancelLendCommand request,
        CancellationToken cancellationToken)
    {
        var lend = _lendRepository.Get(l => l.Code == request.Code.Trim());

        if (lend is null)
        {
            return new Error(
                "ConcludeLend.NotFound",
                "No lend was found for the informed code");
        }

        var cancelResult = lend.Cancel();

        if (cancelResult.IsFailure)
        {
            return cancelResult.Error!;
        }

        _lendRepository.Update(lend);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<LendResponse>(lend);

        return response;
    }
}
