using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Shelter
    {
        public Shelter()
        {
            ShelterPet = new HashSet<ShelterPet>();
        }

        public int ShelterId { get; set; }
        public string Description { get; set; }
        public string Responsable { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        public virtual ICollection<ShelterPet> ShelterPet { get; set; }
    }
}
