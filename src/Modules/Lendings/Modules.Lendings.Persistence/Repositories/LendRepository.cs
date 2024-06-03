using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.Domain.Entities;

namespace DigitalLibrary.Modules.Lendings.Persistence.Repositories;

internal sealed class LendRepository : RepositoryBase<Lend>, ILendRepository
{
    public LendRepository(LendingsDbContext dbContext)
        : base(dbContext)
    {
    }

    public bool IsLent(Guid bookId)
    {
        return Get(l => l.BookId == bookId && l.EndDate > DateTime.Now) is not null;
    }
}
