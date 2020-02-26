using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class ShelterResource
    {
        public ShelterResource()
        {

        }

        public ShelterResource(Shelter shelter)
        {
            ShelterId = shelter.ShelterId;
            Description = shelter.Description;
            Responsable = shelter.Responsable;
            Email = shelter.Email;
            Phone = shelter.Phone;
            Website = shelter.Website;
        }

        public int ShelterId { get; set; }
        public string Description { get; set; }
        public string Responsable { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
    }
}
