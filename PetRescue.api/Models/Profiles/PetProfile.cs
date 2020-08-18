using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetDto>();
            CreateMap<PetDto, Pet>();
        }
    }
}
