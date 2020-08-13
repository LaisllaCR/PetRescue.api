using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class ContactSocialMidiaDto
    {
        public ContactSocialMidiaDto()
        {

        }

        public ContactSocialMidiaDto(ContactSocialMidia contactSocialMidia)
        {
            ContactSocialMidiaId = contactSocialMidia.ContactSocialMidiaId;
            ContactId = contactSocialMidia.ContactId;
            SocialMidiaId = contactSocialMidia.SocialMidiaId;
        }

        public int ContactSocialMidiaId { get; set; }
        public int ContactId { get; set; }
        public int SocialMidiaId { get; set; }
    }
}
