using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Persistence.Repositories;

internal sealed class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(BooksDbContext dbContext)
        : base(dbContext)
    {
    }

    public Book? GetByIsbn10(string isbn10)
    {
        return Get(b => b.Isbn10.Equals(isbn10.Trim()));
    }

    public Book? GetByIsbn13(string isbn13)
    {
        return Get(b => b.Isbn13.Equals(isbn13.Trim()));
    }
}
