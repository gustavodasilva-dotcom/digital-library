using AutoMapper;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Entities;

namespace DigitalLibrary.Modules.Books.Application.Profiles;

public class PublisherProfiles : Profile
{
    public PublisherProfiles()
    {
        CreateMap<Publisher, PublisherContracts.PublisherResponse>();
    }
}
