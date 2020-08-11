using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IPetColorRepository
    {
        IEnumerable<PetColorDto> GetPetColors();
        PetColorDto GetPetColorByID(int id);
        void InsertPetColor(PetColorDto petColor);
        void DeletePetColor(int id);
        void UpdatePetColor(PetColorDto petColor);
        void Save();
        bool PetColorExists(int id);
    }
}
