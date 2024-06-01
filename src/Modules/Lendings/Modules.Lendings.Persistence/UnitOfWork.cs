using DigitalLibrary.Modules.Lendings.Domain.Abstractions;

namespace DigitalLibrary.Modules.Lendings.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly LendingDbContext _dbContext;

    public UnitOfWork(LendingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
