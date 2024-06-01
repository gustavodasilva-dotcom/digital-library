using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Persistence.Repositories;

internal sealed class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(BooksDbContext dbContext)
        : base(dbContext)
    {
    }
}
