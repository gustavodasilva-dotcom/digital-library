using DigitalLibrary.Modules.Patrons.Domain.Abstractions;
using DigitalLibrary.Modules.Patrons.Domain.Entities;

namespace DigitalLibrary.Modules.Patrons.Persistence.Repositories;

internal sealed class PatronRepository : RepositoryBase<Patron>, IPatronRepository
{
    public PatronRepository(PatronsDbContext dbContext)
        : base(dbContext)
    {
    }
}
