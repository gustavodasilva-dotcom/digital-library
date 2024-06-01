using DigitalLibrary.Modules.Books.Domain.Abstractions;

namespace DigitalLibrary.Modules.Books.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly BooksDbContext _context;

    public UnitOfWork(BooksDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
