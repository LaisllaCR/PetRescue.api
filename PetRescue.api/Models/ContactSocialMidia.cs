using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class ContactSocialMidia
    {
        public string ContactSocialMidiaId { get; set; }
        public int ContactId { get; set; }
        public int SocialMidiaId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual SocialMidia SocialMidia { get; set; }
    }
}
