using AutoMapper;
using DigitalLibrary.Modules.Patrons.Application.Contracts;
using DigitalLibrary.Modules.Patrons.Domain.Entities;

namespace DigitalLibrary.Modules.Patrons.Application.Profiles;

public class PatronProfiles : Profile
{
    public PatronProfiles()
    {
        CreateMap<Patron, PatronContracts.PatronResponse>();
    }
}
