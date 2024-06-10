using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Persistence;

namespace DigitalLibrary.Modules.Lendings.Persistence;

internal sealed class UnitOfWork : UnitOfWork<LendingsDbContext>, IUnitOfWork
{
    public UnitOfWork(LendingsDbContext dbContext)
        : base(dbContext)
    {
    }
}
