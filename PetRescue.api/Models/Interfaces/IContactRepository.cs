using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface IContactRepository
    {
        IEnumerable<ContactResource> GetContacts();
        ContactResource GetContactByID(int id);
        void InsertContact(ContactResource contact);
        void DeleteContact(int id);
        void UpdateContact(ContactResource contact);
        void Save();
        bool ContactExists(int id);
    }
}
