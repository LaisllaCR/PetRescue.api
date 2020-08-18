using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class LocationTypeProfile : Profile
    {
        public LocationTypeProfile()
        {
            CreateMap<LocationType, LocationTypeDto>();
        }
    }
}
