using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class PetColorProfile : Profile
    {
        public PetColorProfile()
        {
            CreateMap<PetColor, PetColorDto>();
        }
    }
}
