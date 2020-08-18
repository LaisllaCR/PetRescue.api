using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class PelageProfile : Profile
    {
        public PelageProfile()
        {
            CreateMap<Pelage, PelageDto>();
        }
    }
}
