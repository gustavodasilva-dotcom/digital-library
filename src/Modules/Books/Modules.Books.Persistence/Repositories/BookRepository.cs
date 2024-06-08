using System.Linq.Expressions;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Modules.Books.Persistence.Repositories;

internal sealed class BookRepository : RepositoryBase<Book>, IBookRepository
{
    private readonly BooksDbContext _dbContext;

    public BookRepository(BooksDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override List<Book> GetAll(Expression<Func<Book, bool>> expression)
    {
        return _dbContext.Books
            .Include(b => b.Authors)
            .Include(b => b.Lends)
            .Where(expression)
            .ToList();
    }

    public override Book? Get(Expression<Func<Book, bool>> expression)
    {
        return _dbContext.Books
            .Include(b => b.Authors)
            .Include(b => b.Lends)
            .SingleOrDefault(expression);
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
