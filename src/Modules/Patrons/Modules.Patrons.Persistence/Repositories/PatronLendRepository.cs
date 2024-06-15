using DigitalLibrary.Modules.Patrons.Domain.Abstractions;
using DigitalLibrary.Modules.Patrons.Domain.Entities;

namespace DigitalLibrary.Modules.Patrons.Persistence.Repositories;

internal sealed class PatronLendRepository : RepositoryBase<PatronLend>, IPatronLendRepository
{
    public PatronLendRepository(PatronsDbContext dbContext)
        : base(dbContext)
    {
    }
}
