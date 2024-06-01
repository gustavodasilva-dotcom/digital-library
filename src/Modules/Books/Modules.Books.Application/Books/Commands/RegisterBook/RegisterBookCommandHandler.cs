using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Commands.RegisterBook;

internal sealed class RegisterBookCommandHandler
    : IRequestHandler<RegisterBookCommand, Result<Guid, Error>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterBookCommandHandler(
        IBookRepository bookRepository,
        IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, Error>> Handle(
        RegisterBookCommand request,
        CancellationToken cancellationToken)
    {
        if (_bookRepository.Get(b => b.Isbn10.Equals(request.Isbn10)) != null)
        {
            return new Error(
                "RegisterBook.ExistingIsbn10",
                $"There's already a book registered with the ISBN-10 {request.Isbn10}");
        }

        if (_bookRepository.Get(b => b.Isbn13.Equals(request.Isbn13)) != null)
        {
            return new Error(
                "RegisterBook.ExistingIsbn13",
                $"There's already a book registered with the ISBN-13 {request.Isbn13}");
        }

        var book = Book.Create(
            request.Title,
            request.PublicationDate,
            request.TotalPages,
            request.Isbn10,
            request.Isbn13);

        _bookRepository.Add(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}
