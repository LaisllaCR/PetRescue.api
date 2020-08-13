using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class HairDto
    {
        public HairDto()
        {

        }

        public HairDto(Hair hair)
        {
            HairId = hair.HairId;
            Description = hair.Description;
        }
        
        public int HairId { get; set; }
        public string Description { get; set; }
    }
}
