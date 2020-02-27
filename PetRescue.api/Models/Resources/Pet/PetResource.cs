using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class PetResource
    {
        public PetResource()
        {

        }

        public PetResource(Pet pet)
        {
            PetId = pet.PetId;
            SizeId = pet.SizeId;
            BreedId = pet.BreedId;
            Gender = pet.Gender;
            AgeId = pet.AgeId;
            HairId = pet.PetId;
            SpecieId = pet.SpecieId;
            SpecialNeeds = pet.SpecialNeeds;
            Neuter = pet.Neuter;
            Vaccine = pet.Vaccine;
            Story = pet.Story;
            Leash = pet.Leash;
            LeashDescription = pet.LeashDescription;
            Chip = pet.Chip;
            Weight = pet.Weight;
            Name = pet.Name;
        }

        public int PetId { get; set; }
        public int SizeId { get; set; }
        public int BreedId { get; set; }
        public string Gender { get; set; }
        public int AgeId { get; set; }
        public int HairId { get; set; }
        public int SpecieId { get; set; }
        public string SpecialNeeds { get; set; }
        public string Neuter { get; set; }
        public string Vaccine { get; set; }
        public string Story { get; set; }
        public string Leash { get; set; }
        public string Chip { get; set; }
        public string LeashDescription { get; set; }
        public string Weight { get; set; }
        public string Name { get; set; }
    }
}
