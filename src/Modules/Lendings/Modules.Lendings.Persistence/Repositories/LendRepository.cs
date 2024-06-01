using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.Domain.Entities;

namespace DigitalLibrary.Modules.Lendings.Persistence.Repositories;

internal sealed class LendRepository : RepositoryBase<Lend>, ILendRepository
{
    public LendRepository(LendingDbContext dbContext)
        : base(dbContext)
    {
    }
}
