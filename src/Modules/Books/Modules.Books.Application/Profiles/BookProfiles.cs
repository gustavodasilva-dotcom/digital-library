using AutoMapper;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Application.Profiles;

public class BookProfiles : Profile
{
    public BookProfiles()
    {
        CreateMap<Book, BookResponse>();
    }
}
