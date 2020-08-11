using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class SocialMidiaRepository : Repository<SocialMidia>, ISocialMidiaRepository
    {
        public SocialMidiaRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteSocialMidia(int id)
        {
            try
            {
                SocialMidia socialMidia = dbContext.SocialMidia.Find(id);
                dbContext.SocialMidia.Remove(socialMidia);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public SocialMidiaDto GetSocialMidiaByID(int id)
        {
            try
            {
                return new SocialMidiaDto(dbContext.SocialMidia.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<SocialMidiaDto> GetSocialMidias()
        {
            try
            {
                return (from socialMidia in dbContext.SocialMidia select new SocialMidiaDto(socialMidia)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertSocialMidia(SocialMidiaDto resource)
        {
            try
            {
                SocialMidia socialMidia = new SocialMidia();
                socialMidia.SocialMidiaId = resource.SocialMidiaId;
                socialMidia.Description = resource.Description;
                dbContext.SocialMidia.Add(socialMidia);
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

        public bool SocialMidiaExists(int id)
        {
            try
            {
                return dbContext.SocialMidia.Any(e => e.SocialMidiaId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateSocialMidia(SocialMidiaDto resource)
        {
            try
            {
                SocialMidia socialMidia = dbContext.SocialMidia.Find(resource.SocialMidiaId);

                dbContext.Entry(socialMidia).State = EntityState.Modified;

                socialMidia.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
