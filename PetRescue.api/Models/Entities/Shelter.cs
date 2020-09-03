using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Shelter
    {
        public Shelter()
        {
            ShelterContact = new HashSet<ShelterContact>();
            ShelterPet = new HashSet<ShelterPet>();
            ShelterSocialMidia = new HashSet<ShelterSocialMidia>();
        }

        public int ShelterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string EmailSecondary { get; set; }
        public string Phone { get; set; }
        public string PhoneSecondary { get; set; }
        public string UrlWebsite { get; set; }

        public virtual ICollection<ShelterContact> ShelterContact { get; set; }
        public virtual ICollection<ShelterPet> ShelterPet { get; set; }
        public virtual ICollection<ShelterSocialMidia> ShelterSocialMidia { get; set; }
    }
}
