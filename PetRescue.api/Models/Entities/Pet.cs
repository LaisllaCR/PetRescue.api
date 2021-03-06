﻿using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Pet
    {
        public Pet()
        {
            Event = new HashSet<Event>();
            PetCharacteristic = new HashSet<PetCharacteristic>();
            PetColor = new HashSet<PetColor>();
            PetPhoto = new HashSet<PetPhoto>();
            ShelterPet = new HashSet<ShelterPet>();
        }

        public int PetId { get; set; }
        public int SizeId { get; set; }
        public int BreedId { get; set; }
        public char Gender { get; set; }
        public int AgeId { get; set; }
        public int PelageId { get; set; }
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

        public virtual Age Age { get; set; }
        public virtual Breed Breed { get; set; }
        public virtual Pelage Pelage { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<PetCharacteristic> PetCharacteristic { get; set; }
        public virtual ICollection<PetColor> PetColor { get; set; }
        public virtual ICollection<PetPhoto> PetPhoto { get; set; }
        public virtual ICollection<ShelterPet> ShelterPet { get; set; }
    }
}
