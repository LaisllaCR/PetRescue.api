using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class CharacteristicProfile : Profile
    {
        public CharacteristicProfile()
        {
            CreateMap<Characteristic, CharacteristicDto>();
        }
    }
}
