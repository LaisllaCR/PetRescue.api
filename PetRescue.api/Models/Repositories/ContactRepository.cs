using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteContact(int id)
        {
            try
            {
                Contact contact = dbContext.Contact.Find(id);
                dbContext.Contact.Remove(contact);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ContactDto GetContactByID(int id)
        {
            try
            {
                return new ContactDto(dbContext.Contact.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<ContactDto> GetContacts()
        {
            try
            {
                return (from contact in dbContext.Contact select new ContactDto(contact)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertContact(ContactDto resource)
        {
            try
            {
                Contact contact = new Contact();
                contact.Name = resource.Name;
                contact.PhoneMain = resource.PhoneMain;
                contact.PhoneSecondary = resource.PhoneSecondary;
                contact.Email = resource.Email;

                dbContext.Contact.Add(contact);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Save()
        {
            try
            {
                dbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool ContactExists(int id)
        {
            try
            {
                return dbContext.Contact.Any(e => e.ContactId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateContact(ContactDto resource)
        {
            try
            {
                Contact contact = dbContext.Contact.Find(resource.ContactId);

                dbContext.Entry(contact).State = EntityState.Modified;

                contact.Name = resource.Name;
                contact.PhoneMain = resource.PhoneMain;
                contact.PhoneSecondary = resource.PhoneSecondary;
                contact.Email = resource.Email;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
