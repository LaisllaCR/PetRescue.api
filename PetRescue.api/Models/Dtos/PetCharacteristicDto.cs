using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class PetCharacteristicDto
    {
        public PetCharacteristicDto()
        {

        }
        public int PetCharacteristicId { get; set; }
        public int CharacteristicId { get; set; }
        public int PetId { get; set; }
    }
}
