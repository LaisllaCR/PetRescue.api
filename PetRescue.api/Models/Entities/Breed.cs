using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Breed
    {
        public int BreedId { get; set; }
        public int SpecieId { get; set; }
        public string Description { get; set; }

        public virtual Specie BreedNavigation { get; set; }
    }
}
