using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>();
        }
    }
}
