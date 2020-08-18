using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class EventTypeProfile : Profile
    {
        public EventTypeProfile()
        {
            CreateMap<EventType, EventTypeDto>();
        }
    }
}
