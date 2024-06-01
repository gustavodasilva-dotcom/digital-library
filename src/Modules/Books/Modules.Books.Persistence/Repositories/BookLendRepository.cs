using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Persistence.Repositories;

internal sealed class BookLendRepository : RepositoryBase<BookLend>, IBookLendRepository
{
    public BookLendRepository(BooksDbContext dbContext)
        : base(dbContext)
    {
    }
}
