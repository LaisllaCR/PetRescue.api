using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class SocialMidiaProfile : Profile
    {
        public SocialMidiaProfile()
        {
            CreateMap<SocialMidia, SocialMidiaDto>();
        }
    }
}
