using AutoMapper;
using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Patrons.Application.Contracts;
using DigitalLibrary.Modules.Patrons.Domain.Abstractions;
using DigitalLibrary.Modules.Patrons.Domain.Entities;
using MediatR;

namespace DigitalLibrary.Modules.Patrons.Application;

internal sealed class RegisterPatronCommandHandler
    : IRequestHandler<RegisterPatronCommand, Result<PatronContracts.PatronResponse, Error>>
{
    private readonly IPatronRepository _patronRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterPatronCommandHandler(
        IPatronRepository patronRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _patronRepository = patronRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PatronContracts.PatronResponse, Error>> Handle(
        RegisterPatronCommand request,
        CancellationToken cancellationToken)
    {
        var patron = Patron.Create(
            request.FirstName,
            request.MiddleName,
            request.LastName,
            request.Birthday);

        _patronRepository.Add(patron);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<PatronContracts.PatronResponse>(patron);

        return response;
    }
}
