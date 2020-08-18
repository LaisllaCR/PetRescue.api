using AutoMapper;

namespace PetRescue.api.Models.Profiles
{
    public class PetPhotoProfile : Profile
    {
        public PetPhotoProfile()
        {
            CreateMap<PetPhoto, PetPhotoDto>();
        }
    }
}
