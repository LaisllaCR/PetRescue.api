using System.Collections.Generic;

namespace PetRescue.api.Models.Repositories
{
    public interface IShelterPetRepository
    {
        IEnumerable<ShelterPetResource> GetShelterPets();
        ShelterPetResource GetShelterPetByID(int id);
        void InsertShelterPet(ShelterPetResource shelterPet);
        void DeleteShelterPet(int id);
        void UpdateShelterPet(ShelterPetResource shelterPet);
        void Save();
        bool ShelterPetExists(int id);
    }
}