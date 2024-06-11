using AutoMapper;
using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Lendings.Application.Contracts;
using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.Domain.Constants;
using DigitalLibrary.Modules.Lendings.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Lendings.Application.Lends.Commands.RegisterLend;

internal sealed class RegisterLendCommandHandler
    : IRequestHandler<RegisterLendCommand, Result<LendContracts.LendResponse, Error>>
{
    private readonly ILendRepository _lendRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterLendCommandHandler(
        ILendRepository lendRepository,
        [FromKeyedServices(ServicesConstants.LendingsUnitOfWork)] IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _lendRepository = lendRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<LendContracts.LendResponse, Error>> Handle(
        RegisterLendCommand request,
        CancellationToken cancellationToken)
    {
        if (_lendRepository.IsLent(request.BookId))
        {
            return new Error("RegisterLend.BookIsLent", "This book has already been lent");
        }

        var lend = Lend.Create(
            request.BookId,
            request.PatronId,
            request.StartDate,
            request.EndDate);

        _lendRepository.Add(lend);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<LendContracts.LendResponse>(lend);

        return response;
    }
}
