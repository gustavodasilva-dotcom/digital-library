using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Domain.Abstractions;

public interface IAuthorRepository : IRepositoryBase<Author>
{
    Author? GetByName(string name);
}
