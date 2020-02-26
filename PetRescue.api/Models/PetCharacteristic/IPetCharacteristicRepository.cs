using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public interface IPetCharacteristicRepository
    {
        IEnumerable<PetCharacteristicResource> GetPetCharacteristics();
        PetCharacteristicResource GetPetCharacteristicByID(int id);
        void InsertPetCharacteristic(PetCharacteristicResource resource);
        void DeletePetCharacteristic(int id);
        void UpdatePetCharacteristic(PetCharacteristicResource resource);
        void Save();
        bool PetCharacteristicExists(int id);
    }
}
