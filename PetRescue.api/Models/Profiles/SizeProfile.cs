using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<Size, SizeDto>();
        }
    }
}
