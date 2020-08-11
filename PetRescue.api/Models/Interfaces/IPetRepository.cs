using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IPetRepository
    {
        IEnumerable<PetDto> GetPets();
        PetDto GetPetByID(int id);
        void InsertPet(PetDto pet);
        void DeletePet(int id);
        void UpdatePet(PetDto pet);
        void Save();
        bool PetExists(int id);
    }
}
