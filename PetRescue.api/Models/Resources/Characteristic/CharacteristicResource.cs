using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class CharacteristicResource
    {
        public CharacteristicResource()
        {

        }

        public CharacteristicResource(Characteristics characteristic)
        {
            CharacteristicId = characteristic.CharacteristicId;
            Description = characteristic.Description;
        }

        public int CharacteristicId { get; set; }
        public string Description { get; set; }
    }
}
