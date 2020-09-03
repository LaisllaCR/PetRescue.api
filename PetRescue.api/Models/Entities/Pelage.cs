using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Pelage
    {
        public Pelage()
        {
            Pet = new HashSet<Pet>();
        }

        public int PelageId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Pet> Pet { get; set; }
    }
}
