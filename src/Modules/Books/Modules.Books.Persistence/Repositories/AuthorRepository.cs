using System.Linq.Expressions;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Modules.Books.Persistence.Repositories;

internal sealed class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    private readonly BooksDbContext _dbContext;

    public AuthorRepository(BooksDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override Author? Get(Expression<Func<Author, bool>> expression)
    {
        return _dbContext.Authors
            .Include(a => a.Books)
            .SingleOrDefault(expression);
    }

    public Author? GetByName(string name)
    {
        return Get(a => a.Name.ToLower().Equals(name.ToLower().Trim()));
    }
}
