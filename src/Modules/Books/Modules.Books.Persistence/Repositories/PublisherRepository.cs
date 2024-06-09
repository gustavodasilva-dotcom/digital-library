using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Persistence.Repositories;

internal sealed class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
{
    public PublisherRepository(BooksDbContext dbContext)
        : base(dbContext)
    {
    }

    public Publisher? GetByName(string name)
    {
        return Get(a => a.Name.ToLower().Equals(name.ToLower().Trim()));
    }
}
