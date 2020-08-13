using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public interface IPetCharacteristicRepository
    {
        IEnumerable<PetCharacteristicDto> GetPetCharacteristics();
        PetCharacteristicDto GetPetCharacteristicByID(int id);
        void InsertPetCharacteristic(PetCharacteristicDto resource);
        void DeletePetCharacteristic(int id);
        void UpdatePetCharacteristic(PetCharacteristicDto resource);
        void Save();
        bool PetCharacteristicExists(int id);
    }
}
