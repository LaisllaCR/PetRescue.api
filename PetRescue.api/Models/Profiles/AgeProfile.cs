using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class AgeProfile : Profile
    {
        public AgeProfile()
        {
            CreateMap<Age, AgeDto>();
        }
    }
}
