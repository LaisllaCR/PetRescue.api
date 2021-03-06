﻿using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class ContactSocialMidia
    {
        public int ContactSocialMidiaId { get; set; }
        public int ContactId { get; set; }
        public int SocialMidiaId { get; set; }
        public string Url { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual SocialMidia SocialMidia { get; set; }
    }
}
