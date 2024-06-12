using AutoMapper;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Application.Profiles;

public class AuthorProfiles : Profile
{
    public AuthorProfiles()
    {
        CreateMap<Author, AuthorContracts.AuthorResponse>();
    }
}
