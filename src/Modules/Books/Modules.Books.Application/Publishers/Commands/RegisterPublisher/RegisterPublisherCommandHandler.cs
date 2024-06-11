using AutoMapper;
using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Constants;
using DigitalLibrary.Modules.Books.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Application.Publishers.Commands.RegisterPublisher;

internal sealed class RegisterPublisherCommandHandler
    : IRequestHandler<RegisterPublisherCommand, Result<PublisherContracts.PublisherResponse, Error>>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterPublisherCommandHandler(
        IPublisherRepository publisherRepository,
        [FromKeyedServices(ServicesConstants.BooksUnitOfWork)] IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<PublisherContracts.PublisherResponse, Error>> Handle(
        RegisterPublisherCommand request,
        CancellationToken cancellationToken)
    {
        var publisher = _publisherRepository.GetByName(request.Name);
        
        if (publisher is not null)
        {
            return new Error(
                "RegisterAuthor.ExistingPublisher",
                $"There's already a publisher registered with the name {request.Name}");
        }

        publisher = Publisher.Create(request.Name);

        _publisherRepository.Add(publisher);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<PublisherContracts.PublisherResponse>(publisher);

        return response;
    }
}
