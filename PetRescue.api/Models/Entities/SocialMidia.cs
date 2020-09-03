using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class SocialMidia
    {
        public SocialMidia()
        {
            ContactSocialMidia = new HashSet<ContactSocialMidia>();
            ShelterSocialMidia = new HashSet<ShelterSocialMidia>();
        }

        public int SocialMidiaId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ContactSocialMidia> ContactSocialMidia { get; set; }
        public virtual ICollection<ShelterSocialMidia> ShelterSocialMidia { get; set; }
    }
}
