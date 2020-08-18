using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Contact
    {
        public Contact()
        {
            ContactSocialMidia = new HashSet<ContactSocialMidia>();
        }

        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PhoneSecondary { get; set; }
        public string Email { get; set; }
        public string EmailSecondary { get; set; }

        public virtual ICollection<ContactSocialMidia> ContactSocialMidia { get; set; }
    }
}
