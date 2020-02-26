using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IPetColorRepository
    {
        IEnumerable<PetColorResource> GetPetColors();
        PetColorResource GetPetColorByID(int id);
        void InsertPetColor(PetColorResource petColor);
        void DeletePetColor(int id);
        void UpdatePetColor(PetColorResource petColor);
        void Save();
        bool PetColorExists(int id);
    }
}
