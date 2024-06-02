using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Domain.Abstractions;

public interface IBookRepository : IRepositoryBase<Book>
{
    Book? GetByIsbn10(string isbn10);

    Book? GetByIsbn13(string isbn13);
}
