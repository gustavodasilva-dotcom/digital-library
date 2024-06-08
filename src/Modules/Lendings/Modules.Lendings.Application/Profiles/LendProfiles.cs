using AutoMapper;
using DigitalLibrary.Modules.Lendings.Application.Contracts;
using DigitalLibrary.Modules.Lendings.Domain.Entities;

namespace DigitalLibrary.Modules.Lendings.Application.Profiles;

public class LendProfiles : Profile
{
    public LendProfiles()
    {
        CreateMap<Lend, LendResponse>();
    }
}
