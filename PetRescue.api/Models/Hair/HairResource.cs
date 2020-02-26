using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class HairResource
    {
        public HairResource()
        {

        }

        public HairResource(Hair hair)
        {
            HairId = hair.HairId;
            Description = hair.Description;
        }
        
        public int HairId { get; set; }
        public string Description { get; set; }
    }
}
