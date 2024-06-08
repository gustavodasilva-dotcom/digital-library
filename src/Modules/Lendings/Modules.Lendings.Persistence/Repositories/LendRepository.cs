using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.Domain.Entities;
using DigitalLibrary.Modules.Lendings.Domain.Enumerations;

namespace DigitalLibrary.Modules.Lendings.Persistence.Repositories;

internal sealed class LendRepository : RepositoryBase<Lend>, ILendRepository
{
    public LendRepository(LendingsDbContext dbContext)
        : base(dbContext)
    {
    }

    public bool IsLent(Guid bookId)
    {
        var bookLent = Get(l => l.BookId == bookId &&
            (l.Status == LendStatuses.Open || l.Status == LendStatuses.Late));

        return bookLent is not null;
    }
}
