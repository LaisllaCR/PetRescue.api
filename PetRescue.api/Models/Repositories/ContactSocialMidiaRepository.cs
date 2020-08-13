using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class ContactSocialMidiaRepository : IContactSocialMidiaRepository
    {
        private readonly dbContext _context;

        public ContactSocialMidiaRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteContactSocialMidia(int id)
        {
            try
            {
                ContactSocialMidia contactSocialMidia = _context.ContactSocialMidia.Find(id);
                _context.ContactSocialMidia.Remove(contactSocialMidia);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ContactSocialMidiaDto GetContactSocialMidiaByID(int id)
        {
            try
            {
                return new ContactSocialMidiaDto(_context.ContactSocialMidia.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<ContactSocialMidiaDto> GetContactSocialMidias()
        {
            try
            {
                return (from contactSocialMidia in _context.ContactSocialMidia select new ContactSocialMidiaDto(contactSocialMidia)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertContactSocialMidia(ContactSocialMidiaDto resource)
        {
            try
            {
                ContactSocialMidia contactSocialMidia = new ContactSocialMidia();
                contactSocialMidia.SocialMidiaId = resource.SocialMidiaId;
                contactSocialMidia.ContactId = resource.ContactId;

                _context.ContactSocialMidia.Add(contactSocialMidia);
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

        public bool ContactSocialMidiaExists(int id)
        {
            try
            {
                return _context.ContactSocialMidia.Any(e => e.ContactSocialMidiaId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateContactSocialMidia(ContactSocialMidiaDto resource)
        {
            try
            {
                ContactSocialMidia contactSocialMidia = _context.ContactSocialMidia.Find(resource.ContactSocialMidiaId);

                _context.Entry(contactSocialMidia).State = EntityState.Modified;

                contactSocialMidia.SocialMidiaId = resource.SocialMidiaId;
                contactSocialMidia.ContactId = resource.ContactId;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
