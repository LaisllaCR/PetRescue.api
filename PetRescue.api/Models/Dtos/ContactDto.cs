using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class ContactDto
    {
        public ContactDto()
        {

        }

        public ContactDto(Contact contact)
        {
            ContactId = contact.ContactId;
            Name = contact.Name;
            PhoneMain = contact.PhoneMain;
            PhoneSecondary = contact.PhoneSecondary;
            Email = contact.Email;
        }

        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneMain { get; set; }
        public string PhoneSecondary { get; set; }
        public string Email { get; set; }
    }
}
