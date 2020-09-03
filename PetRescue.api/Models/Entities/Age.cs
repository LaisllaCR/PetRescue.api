using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Age
    {
        public Age()
        {
            Pet = new HashSet<Pet>();
        }

        public int AgeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Pet> Pet { get; set; }
    }
}
