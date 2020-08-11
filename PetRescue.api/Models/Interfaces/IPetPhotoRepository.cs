using System.Collections.Generic;

namespace PetRescue.api.Models.Interfaces
{
    public interface IPetPhotoRepository
    {
        IEnumerable<PetPhotoDto> GetPetPhotos();
        PetPhotoDto GetPetPhotoByID(int id);
        void InsertPetPhoto(PetPhotoDto petPhoto);
        void DeletePetPhoto(int id);
        void UpdatePetPhoto(PetPhotoDto petPhoto);
        void Save();
        bool PetPhotoExists(int id);
    }
}
