using AutoMapper;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Application.Profiles;

public class BookProfiles : Profile
{
    public BookProfiles()
    {
        CreateMap<Book, BookContracts.BookResponse>();

        CreateMap<BookAuthor, BookContracts.AuthorResponse>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Author.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.AuthorType));

        CreateMap<Publisher, BookContracts.PublisherResponse>();
    }
}
