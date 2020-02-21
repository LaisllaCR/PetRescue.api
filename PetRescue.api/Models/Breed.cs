using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Breed
    {
        public Breed()
        {
            Pet = new HashSet<Pet>();
        }

        public int BreedId { get; set; }
        public int SpecieId { get; set; }
        public string Description { get; set; }

        public virtual Specie BreedNavigation { get; set; }
        public virtual ICollection<Pet> Pet { get; set; }
    }
}
