using AutoMapper;
using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Application.Contracts;
using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using MediatR;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.ConcludeLend;

internal sealed class ConcludeLendCommandHandler
    : IRequestHandler<ConcludeLendCommand, Result<LendResponse, Error>>
{
    private readonly ILendRepository _lendRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ConcludeLendCommandHandler(
        ILendRepository lendRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _lendRepository = lendRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<LendResponse, Error>> Handle(
        ConcludeLendCommand request,
        CancellationToken cancellationToken)
    {
        var lend = _lendRepository.Get(l => l.Code == request.Code.Trim());

        if (lend is null)
        {
            return new Error(
                "ConcludeLend.NotFound",
                "No lend was found for the informed code");
        }

        lend.Conclude();

        _lendRepository.Update(lend);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<LendResponse>(lend);

        return response;
    }
}
