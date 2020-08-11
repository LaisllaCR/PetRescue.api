using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IContactSocialMidiaRepository
    {
        IEnumerable<ContactSocialMidiaDto> GetContactSocialMidias();
        ContactSocialMidiaDto GetContactSocialMidiaByID(int id);
        void InsertContactSocialMidia(ContactSocialMidiaDto contactSocialMidia);
        void DeleteContactSocialMidia(int id);
        void UpdateContactSocialMidia(ContactSocialMidiaDto contactSocialMidia);
        void Save();
        bool ContactSocialMidiaExists(int id);
    }
}
