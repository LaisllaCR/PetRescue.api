using AutoMapper;
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
        private readonly IMapper _mapper;

        public ContactRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteContact(int id)
        {
            try
            {
                Contact contact = _context.Contact.Find(id);
                _context.Contact.Remove(contact);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ContactDto GetContactByID(int id)
        {
            try
            {
                Contact contact = _context.Contact.Find(id);
                return _mapper.Map<ContactDto>(contact);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ContactDto> GetContacts()
        {
            try
            {
                List<Contact> allContacts = _context.Contact.OrderBy(x => x.ContactId).ToList();

                List<ContactDto> allContactsDtos = _mapper.Map<List<Contact>, List<ContactDto>>(allContacts);

                return allContactsDtos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertContact(ContactDto resource)
        {
            try
            {
                Contact contact = new Contact();
                contact.Name = resource.Name;
                contact.Phone = resource.PhoneMain;
                contact.PhoneSecondary = resource.PhoneSecondary;
                contact.Email = resource.Email;

                _context.Contact.Add(contact);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool ContactExists(int id)
        {
            try
            {
                return _context.Contact.Any(e => e.ContactId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateContact(ContactDto resource)
        {
            try
            {
                Contact contact = _context.Contact.Find(resource.ContactId);

                _context.Entry(contact).State = EntityState.Modified;

                contact.Name = resource.Name;
                contact.Phone = resource.PhoneMain;
                contact.PhoneSecondary = resource.PhoneSecondary;
                contact.Email = resource.Email;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
