using AutoMapper;
using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Constants;
using DigitalLibrary.Modules.Books.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Application.Authors.Commands.RegisterAuthor;

internal sealed class RegisterAuthorCommandHandler
    : IRequestHandler<RegisterAuthorCommand, Result<AuthorContracts.AuthorResponse, Error>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterAuthorCommandHandler(
        IAuthorRepository authorRepository,
        [FromKeyedServices(ServicesConstants.BooksUnitOfWork)] IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<AuthorContracts.AuthorResponse, Error>> Handle(
        RegisterAuthorCommand request,
        CancellationToken cancellationToken)
    {
        if (_authorRepository.GetByName(request.Name) is not null)
        {
            return new Error(
                "RegisterAuthor.ExistingAuthor",
                $"There's already an author registered with the name {request.Name}");
        }

        var author = Author.Create(request.Name, request.About);

        _authorRepository.Add(author);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<AuthorContracts.AuthorResponse>(author);

        return response;
    }
}
