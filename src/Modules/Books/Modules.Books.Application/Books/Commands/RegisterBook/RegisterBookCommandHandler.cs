using AutoMapper;
using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Commands.RegisterBook;

internal sealed class RegisterBookCommandHandler
    : IRequestHandler<RegisterBookCommand, Result<BookContracts.BookResponse, Error>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IPublisherRepository _publisherRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterBookCommandHandler(
        IBookRepository bookRepository,
        IPublisherRepository publisherRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _bookRepository = bookRepository;
        _publisherRepository = publisherRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<BookContracts.BookResponse, Error>> Handle(
        RegisterBookCommand request,
        CancellationToken cancellationToken)
    {
        if (_bookRepository.GetByIsbn10(request.Isbn10) is not null)
        {
            return new Error(
                "RegisterBook.ExistingBook",
                $"There's already a book registered with the ISBN-10 {request.Isbn10}");
        }

        if (_bookRepository.GetByIsbn13(request.Isbn13) is not null)
        {
            return new Error(
                "RegisterBook.ExistingBook",
                $"There's already a book registered with the ISBN-13 {request.Isbn13}");
        }

        var publisher = _publisherRepository.Get(p => p.Id == request.PublisherId);

        if (publisher is null)
        {
            return new Error(
                "RegisterBook.PublisherNotFound",
                $"No publisher was found with the id {request.PublisherId}");
        }

        var book = Book.Create(
            request.Title,
            request.PublicationDate,
            request.TotalPages,
            request.Edition,
            request.Isbn10,
            request.Isbn13,
            request.PublisherId);

        var publisherResult = publisher.AddBook(book);

        if (publisherResult.IsFailure)
        {
            return publisherResult.Error!;
        }

        _bookRepository.Add(book);

        _publisherRepository.Update(publisher);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<BookContracts.BookResponse>(book);

        return response;
    }
}
