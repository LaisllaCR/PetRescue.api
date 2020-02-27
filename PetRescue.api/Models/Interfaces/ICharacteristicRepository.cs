using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface ICharacteristicRepository
    {
        IEnumerable<CharacteristicResource> GetCharacteristics();
        CharacteristicResource GetCharacteristicByID(int id);
        void InsertCharacteristic(CharacteristicResource characteristic);
        void DeleteCharacteristic(int id);
        void UpdateCharacteristic(CharacteristicResource characteristic);
        void Save();
        bool CharacteristicExists(int id);
    }
}
