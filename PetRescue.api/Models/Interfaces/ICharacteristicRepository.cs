using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface ICharacteristicRepository
    {
        IEnumerable<CharacteristicDto> GetCharacteristics();
        CharacteristicDto GetCharacteristicByID(int id);
        void InsertCharacteristic(CharacteristicDto characteristic);
        void DeleteCharacteristic(int id);
        void UpdateCharacteristic(CharacteristicDto characteristic);
        void Save();
        bool CharacteristicExists(int id);
    }
}
