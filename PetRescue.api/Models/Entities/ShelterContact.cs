using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class ShelterContact
    {
        public int ShelterContactId { get; set; }
        public int ShelterId { get; set; }
        public int ContactId { get; set; }
        public string Description { get; set; }
    }
}
