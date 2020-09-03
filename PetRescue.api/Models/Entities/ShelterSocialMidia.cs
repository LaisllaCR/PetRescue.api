using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class ShelterSocialMidia
    {
        public int ShelterSocialMidiaId { get; set; }
        public int ShelterId { get; set; }
        public int SocialMidiaId { get; set; }

        public virtual Shelter Shelter { get; set; }
        public virtual SocialMidia SocialMidia { get; set; }
    }
}
