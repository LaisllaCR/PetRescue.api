using System.Collections.Generic;

namespace PetRescue.api.Models.Repositories
{
    public interface IShelterPetRepository
    {
        IEnumerable<ShelterPetDto> GetShelterPets();
        ShelterPetDto GetShelterPetByID(int id);
        void InsertShelterPet(ShelterPetDto shelterPet);
        void DeleteShelterPet(int id);
        void UpdateShelterPet(ShelterPetDto shelterPet);
        void Save();
        bool ShelterPetExists(int id);
    }
}