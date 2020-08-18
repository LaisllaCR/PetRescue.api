using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class ShelterPetProfile : Profile
    {
        public ShelterPetProfile()
        {
            CreateMap<ShelterPet, ShelterPetDto>();
        }
    }
}
