using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Domain.Abstractions;

public interface IPublisherRepository : IRepositoryBase<Publisher>
{
    Publisher? GetByName(string name);
}
