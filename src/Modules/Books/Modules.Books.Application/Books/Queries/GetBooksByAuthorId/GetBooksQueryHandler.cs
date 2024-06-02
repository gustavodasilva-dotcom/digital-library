using AutoMapper;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using MediatR;

namespace DigitalLibrary.Modules.Books.Application.Queries.GetBooksByAuthorId;

internal sealed class GetBooksQueryHandler
    : IRequestHandler<GetBooksByAuthorIdQuery, IEnumerable<BookResponse>>
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

    public Task<IEnumerable<BookResponse>> Handle(
        GetBooksByAuthorIdQuery request,
        CancellationToken cancellationToken)
    {
        var books = _bookRepository.GetAll(b => b.AuthorId == request.AuthorId);

        var result = _mapper.Map<IEnumerable<BookResponse>>(books);

        return Task.FromResult(result);
    }
}
