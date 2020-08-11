using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class ContactSocialMidiaRepository : Repository<ContactSocialMidia>, IContactSocialMidiaRepository
    {
        public ContactSocialMidiaRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteContactSocialMidia(int id)
        {
            try
            {
                ContactSocialMidia contactSocialMidia = dbContext.ContactSocialMidia.Find(id);
                dbContext.ContactSocialMidia.Remove(contactSocialMidia);
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
                return new ContactSocialMidiaDto(dbContext.ContactSocialMidia.Find(id));

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
                return (from contactSocialMidia in dbContext.ContactSocialMidia select new ContactSocialMidiaDto(contactSocialMidia)).ToList();

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

                dbContext.ContactSocialMidia.Add(contactSocialMidia);
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

        public bool ContactSocialMidiaExists(int id)
        {
            try
            {
                return dbContext.ContactSocialMidia.Any(e => e.ContactSocialMidiaId == id);

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
                ContactSocialMidia contactSocialMidia = dbContext.ContactSocialMidia.Find(resource.ContactSocialMidiaId);

                dbContext.Entry(contactSocialMidia).State = EntityState.Modified;

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
