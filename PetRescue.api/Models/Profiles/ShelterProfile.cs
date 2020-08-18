using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class ShelterProfile : Profile
    {
        public ShelterProfile()
        {
            CreateMap<Shelter, ShelterDto>();
        }
    }
}
