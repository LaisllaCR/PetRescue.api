using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IContactSocialMidiaRepository
    {
        IEnumerable<ContactSocialMidiaResource> GetContactSocialMidias();
        ContactSocialMidiaResource GetContactSocialMidiaByID(int id);
        void InsertContactSocialMidia(ContactSocialMidiaResource contactSocialMidia);
        void DeleteContactSocialMidia(int id);
        void UpdateContactSocialMidia(ContactSocialMidiaResource contactSocialMidia);
        void Save();
        bool ContactSocialMidiaExists(int id);
    }
}
