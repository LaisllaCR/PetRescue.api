using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Hair
    {
        public Hair()
        {
            Pet = new HashSet<Pet>();
        }

        public int HairId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Pet> Pet { get; set; }
    }
}
