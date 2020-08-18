using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class EventStatusProfile : Profile
    {
        public EventStatusProfile()
        {
            CreateMap<EventStatus, EventStatusDto>();
        }
    }
}
