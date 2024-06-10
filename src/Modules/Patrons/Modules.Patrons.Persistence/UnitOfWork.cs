using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Common.Persistence;

namespace DigitalLibrary.Modules.Patrons.Persistence;

internal sealed class UnitOfWork : UnitOfWork<PatronsDbContext>, IUnitOfWork
{
    public UnitOfWork(PatronsDbContext dbContext)
        : base(dbContext)
    {
    }
}
