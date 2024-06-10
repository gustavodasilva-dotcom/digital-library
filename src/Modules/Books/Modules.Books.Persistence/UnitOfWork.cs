using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Persistence;

namespace DigitalLibrary.Modules.Books.Persistence;

internal sealed class UnitOfWork : UnitOfWork<BooksDbContext>, IUnitOfWork
{
    public UnitOfWork(BooksDbContext dbContext)
        : base(dbContext)
    {
    }
}
