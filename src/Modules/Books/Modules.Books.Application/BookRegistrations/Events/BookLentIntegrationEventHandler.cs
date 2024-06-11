using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Application.Exceptions;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Constants;
using DigitalLibrary.Modules.Books.Domain.Entities;
using DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Application.BookRegistrations.Events;

public sealed class BookLentIntegrationEventHandler
    : IConsumer<BookLentIntegrationEvent>
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookLendRepository _bookLendRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookLentIntegrationEventHandler(
        IBookRepository bookRepository,
        IBookLendRepository bookLendRepository,
        [FromKeyedServices(ServicesConstants.BooksUnitOfWork)] IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _bookLendRepository = bookLendRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<BookLentIntegrationEvent> context)
    {
        BookLentIntegrationEvent message = context.Message;

        var book = _bookRepository.Get(b => b.Id == message.BookId);

        if (book is null)
        {
            throw new BookNotFoundException(message.BookId);
        }

        if (!book.IsAvailable)
        {
            throw new BookIsNotAvailableException(book.Title);
        }

        var bookLend = BookLend.Create(
            message.BookId,
            message.LendId,
            message.StartDate,
            message.EndDate,
            message.CreatedDate);
        
        _bookLendRepository.Add(bookLend);

        book.AddLend(bookLend);
        book.TurnBookIntoUnavailable();

        _bookRepository.Update(book);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
