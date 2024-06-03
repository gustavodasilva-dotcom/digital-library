using DigitalLibrary.Modules.Lendings.Domain.Abstractions;

namespace DigitalLibrary.Modules.Lendings.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly LendingsDbContext _dbContext;

    public UnitOfWork(LendingsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
