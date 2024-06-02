using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Commands.RegisterBook;

internal sealed class RegisterBookCommandHandler
    : IRequestHandler<RegisterBookCommand, Result<Guid, Error>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterBookCommandHandler(
        IBookRepository bookRepository,
        IAuthorRepository authorRepository,
        IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, Error>> Handle(
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

        var author = _authorRepository.Get(a => a.Id == request.AuthorId);

        if (author is null)
        {
            return new Error(
                "RegisterBook.AuthorNotFound",
                $"No author was found with the id {request.AuthorId}");
        }

        var book = Book.Create(
            request.Title,
            request.PublicationDate,
            request.TotalPages,
            request.Isbn10,
            request.Isbn13,
            request.AuthorId);

        var addBookResult = author.AddBook(book);
        
        if (addBookResult.IsFailure)
        {
            return addBookResult.Error!;
        }

        _bookRepository.Add(book);

        _authorRepository.Update(author);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}
