using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Specie
    {
        public int SpecieId { get; set; }
        public string Description { get; set; }

        public virtual Breed Breed { get; set; }
    }
}
