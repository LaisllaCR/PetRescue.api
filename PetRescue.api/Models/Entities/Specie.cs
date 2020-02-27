using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Specie
    {
        public Specie()
        {
            Pet = new HashSet<Pet>();
        }

        public int SpecieId { get; set; }
        public string Description { get; set; }

        public virtual Breed Breed { get; set; }
        public virtual ICollection<Pet> Pet { get; set; }
    }
}
