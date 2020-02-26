using System.Collections.Generic;

namespace PetRescue.api.Models.Interfaces
{
    public interface IPetPhotoRepository
    {
        IEnumerable<PetPhotoResource> GetPetPhotos();
        PetPhotoResource GetPetPhotoByID(int id);
        void InsertPetPhoto(PetPhotoResource petPhoto);
        void DeletePetPhoto(int id);
        void UpdatePetPhoto(PetPhotoResource petPhoto);
        void Save();
        bool PetPhotoExists(int id);
    }
}
