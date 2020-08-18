using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Pet
    {
        public int PetId { get; set; }
        public int SizeId { get; set; }
        public int BreedId { get; set; }
        public char Gender { get; set; }
        public int AgeId { get; set; }
        public int PelageId { get; set; }
        public int SpecieId { get; set; }
        public bool SpecialNeeds { get; set; }
        public bool Neuter { get; set; }
        public bool Vacine { get; set; }
        public bool Leash { get; set; }
        public bool Chip { get; set; }
        public string SpecialNeedsDescription { get; set; }
        public string LeashDescription { get; set; }
        public string Name { get; set; }
        public string Story { get; set; }
        public string Weight { get; set; }
    }
}
