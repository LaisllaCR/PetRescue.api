using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class ContactSocialMidiaProfile : Profile
    {
        public ContactSocialMidiaProfile()
        {
            CreateMap<ContactSocialMidia, ContactSocialMidiaDto>();
        }
    }
}
