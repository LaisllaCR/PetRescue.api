using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class ShelterDto
    {
        public ShelterDto()
        {

        }
        public int ShelterId { get; set; }
        public string Description { get; set; }
        public string Responsable { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
    }
}
