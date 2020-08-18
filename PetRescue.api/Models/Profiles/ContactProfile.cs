using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>();
        }
    }
}
