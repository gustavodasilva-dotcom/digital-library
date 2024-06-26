using AutoMapper;
using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Domain.Shared;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Constants;
using DigitalLibrary.Modules.Books.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Application.Commands.AddAuthorToBook;

internal sealed class AddAuthorToBookCommandHandler
    : IRequestHandler<AddAuthorToBookCommand, Result<BookContracts.BookResponse, Error>>
{
    private readonly IBookAuthorRepository _bookAuthorRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddAuthorToBookCommandHandler(
        IBookAuthorRepository bookAuthorRepository,
        IAuthorRepository authorRepository,
        IBookRepository bookRepository,
        [FromKeyedServices(ServicesConstants.BooksUnitOfWork)] IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _bookAuthorRepository = bookAuthorRepository;
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<BookContracts.BookResponse, Error>> Handle(
        AddAuthorToBookCommand request,
        CancellationToken cancellationToken)
    {
        var author = _authorRepository.Get(a => a.Id == request.AuthorId);

        if (author is null)
        {
            return new Error(
                "AddAuthorToBook.AuthorNotFound",
                $"No author was found with the id {request.AuthorId}");
        }

        var book = _bookRepository.Get(b => b.Id == request.BookId);

        if (book is null)
        {
            return new Error(
                "AddAuthorToBook.BookNotFound",
                $"No book was found with the id {request.BookId}");
        }

        var bookAuthor = BookAuthor.Create(
            request.AuthorType,
            request.BookId,
            request.AuthorId);

        var bookAuthorResult = book.AddBookAuthor(bookAuthor);

        if (bookAuthorResult.IsFailure)
        {
            return bookAuthorResult.Error!;
        }

        _bookAuthorRepository.Add(bookAuthor);

        _bookRepository.Update(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<BookContracts.BookResponse>(book);

        return response;
    }
}
