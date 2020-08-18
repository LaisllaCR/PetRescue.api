using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class BreedProfile : Profile
    {
        public BreedProfile()
        {
            CreateMap<Breed, BreedDto>();
        }
    }
}
