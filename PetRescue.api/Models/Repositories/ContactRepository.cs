using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly dbContext _context;

        public ContactRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void DeleteContact(int id)
        {
            try
            {
                Contact contact = _context.Contact.Find(id);
                _context.Contact.Remove(contact);
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
                return new ContactDto(_context.Contact.Find(id));

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
                return (from contact in _context.Contact select new ContactDto(contact)).ToList();

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

                _context.Contact.Add(contact);
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
                _context.SaveChanges();

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
                return _context.Contact.Any(e => e.ContactId == id);

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
                Contact contact = _context.Contact.Find(resource.ContactId);

                _context.Entry(contact).State = EntityState.Modified;

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
