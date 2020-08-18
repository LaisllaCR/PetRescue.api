using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class PetColorDto
    {
        public PetColorDto()
        {

        }

        public int PetColorId { get; set; }
        public int PetId { get; set; }
        public int ColorId { get; set; }
    }
}
