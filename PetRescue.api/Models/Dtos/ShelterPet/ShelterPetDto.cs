using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class ShelterPetDto
    {
        public ShelterPetDto()
        {

        }

        public ShelterPetDto(ShelterPet shelterPet)
        {
            ShelterId = shelterPet.ShelterId;
            PetId = shelterPet.PetId;
            ShelterPetId = shelterPet.ShelterPetId;
        }

        public int ShelterPetId { get; set; }
        public int PetId { get; set; }
        public int ShelterId { get; set; }
    }
}
