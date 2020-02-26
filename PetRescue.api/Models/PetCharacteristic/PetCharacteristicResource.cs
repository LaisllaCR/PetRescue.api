using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class PetCharacteristicResource
    {
        public PetCharacteristicResource()
        {

        }

        public PetCharacteristicResource(PetCharacteristic petCharacteristic)
        {
            PetCharacteristicId = petCharacteristic.PetCharacteristicId;
            CharacteristicId = petCharacteristic.CharacteristicId;
            PetId = petCharacteristic.PetId;
        }
        public int PetCharacteristicId { get; set; }
        public int CharacteristicId { get; set; }
        public int PetId { get; set; }
    }
}
