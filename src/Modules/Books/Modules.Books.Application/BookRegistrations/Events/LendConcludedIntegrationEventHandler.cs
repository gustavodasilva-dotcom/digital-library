using DigitalLibrary.Modules.Books.Application.Exceptions;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.IntegrationEvents.Contracts;
using MassTransit;

namespace DigitalLibrary.Modules.Books.Application.BookRegistrations.Events;

public sealed class LendConcludedIntegrationEventHandler
    : IConsumer<LendConcludedIntegrationEvent>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LendConcludedIntegrationEventHandler(
        IBookRepository bookRepository,
        IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<LendConcludedIntegrationEvent> context)
    {
        LendConcludedIntegrationEvent message = context.Message;

        var book = _bookRepository.Get(b => b.Id == message.BookId);

        if (book is null)
        {
            throw new BookNotFoundException(message.BookId);
        }

        book.TurnBookIntoAvailable();

        _bookRepository.Update(book);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
