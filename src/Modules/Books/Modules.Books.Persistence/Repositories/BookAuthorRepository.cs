using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Persistence.Repositories;

internal sealed class BookAuthorRepository : RepositoryBase<BookAuthor>, IBookAuthorRepository
{
    public BookAuthorRepository(BooksDbContext dbContext)
        : base(dbContext)
    {
    }
}
