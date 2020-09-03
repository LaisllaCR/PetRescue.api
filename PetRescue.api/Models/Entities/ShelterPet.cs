using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class ShelterPet
    {
        public int ShelterPetId { get; set; }
        public int ShelterId { get; set; }
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual Shelter Shelter { get; set; }
    }
}
