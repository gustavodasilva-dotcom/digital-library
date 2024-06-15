using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;
using DigitalLibrary.Modules.Patrons.Application.Exceptions;
using DigitalLibrary.Modules.Patrons.Domain.Abstractions;
using DigitalLibrary.Modules.Patrons.Domain.Constants;
using DigitalLibrary.Modules.Patrons.Domain.Entities;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Patrons.Application.PatronRegistrations.Events;

public sealed class PatronLentIntegrationEventHandler
    : IConsumer<PatronLentIntegrationEvent>
{
    private readonly IPatronRepository _patronRepository;
    private readonly IPatronLendRepository _patronLendRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PatronLentIntegrationEventHandler(
        IPatronRepository patronRepository,
        IPatronLendRepository patronLendRepository,
        [FromKeyedServices(ServicesConstants.PatronsUnitOfWork)] IUnitOfWork unitOfWork)
    {
        _patronRepository = patronRepository;
        _patronLendRepository = patronLendRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<PatronLentIntegrationEvent> context)
    {
        PatronLentIntegrationEvent message = context.Message;

        var patron = _patronRepository.Get(p => p.Id == message.PatronId);

        if (patron is null)
        {
            throw new PatronNotFoundException(message.PatronId);
        }

        var patronLend = PatronLend.Create(
            message.PatronId,
            message.LendId,
            message.StartDate,
            message.EndDate,
            message.CreatedDate);

        var patronLendResult = patron.AddLend(patronLend);

        if (patronLendResult.IsFailure)
        {
            throw new NotAllowedOperationException(patronLendResult.Error!);
        }

        _patronLendRepository.Add(patronLend);
        _patronRepository.Update(patron);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
