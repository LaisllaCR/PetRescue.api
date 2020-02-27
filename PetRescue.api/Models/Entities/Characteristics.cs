using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Characteristics
    {
        public Characteristics()
        {
            PetCharacteristic = new HashSet<PetCharacteristic>();
        }

        public int CharacteristicId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PetCharacteristic> PetCharacteristic { get; set; }
    }
}
