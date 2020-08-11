using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IContactRepository
    {
        IEnumerable<ContactDto> GetContacts();
        ContactDto GetContactByID(int id);
        void InsertContact(ContactDto contact);
        void DeleteContact(int id);
        void UpdateContact(ContactDto contact);
        void Save();
        bool ContactExists(int id);
    }
}
