using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Constants;
using DigitalLibrary.Modules.Books.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Application.Authors.Commands.RegisterAuthor;

internal sealed class RegisterAuthorCommandHandler
    : IRequestHandler<RegisterAuthorCommand, Result<Guid, Error>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterAuthorCommandHandler(
        IAuthorRepository authorRepository,
        [FromKeyedServices(ServicesConstants.BooksUnitOfWork)] IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, Error>> Handle(
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

        return author.Id;
    }
}
