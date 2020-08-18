using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class SpecieProfile : Profile
    {
        public SpecieProfile()
        {
            CreateMap<Specie, SpecieDto>();
        }
    }
}
