using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IPetRepository
    {
        IEnumerable<PetResource> GetPets();
        PetResource GetPetByID(int id);
        void InsertPet(PetResource pet);
        void DeletePet(int id);
        void UpdatePet(PetResource pet);
        void Save();
        bool PetExists(int id);
    }
}
