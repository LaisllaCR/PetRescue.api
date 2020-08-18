using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class PetCharacteristicProfile : Profile
    {
        public PetCharacteristicProfile()
        {
            CreateMap<PetCharacteristic, PetCharacteristicDto>();
        }
    }
}
