using AutoMapper;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Queries.GetBooksByAuthorId;

internal sealed class GetBooksQueryHandler
    : IRequestHandler<GetBooksByAuthorIdQuery, IEnumerable<BookContracts.BookResponse>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(
        IBookRepository bookRepository,
        IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public Task<IEnumerable<BookContracts.BookResponse>> Handle(
        GetBooksByAuthorIdQuery request,
        CancellationToken cancellationToken)
    {
        var books = _bookRepository.GetAll(b => b.Authors.Any(a => a.AuthorId == request.AuthorId));

        var result = _mapper.Map<IEnumerable<BookContracts.BookResponse>>(books);

        return Task.FromResult(result);
    }
}
