using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class HairRepository : Repository<Hair>, IHairRepository
    {
        public HairRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteHair(int id)
        {
            try
            {
                Hair specie = dbContext.Hair.Find(id);
                dbContext.Hair.Remove(specie);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public HairResource GetHairByID(int id)
        {
            try
            {
                return new HairResource(dbContext.Hair.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }     
        }

        public IEnumerable<HairResource> GetHairs()
        {
            try
            {
                return (from hair in dbContext.Hair select new HairResource(hair)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }    
        }

        public void InsertHair(HairResource resource)
        {
            try
            {
                Hair hair = new Hair();
                hair.HairId = resource.HairId;
                hair.Description = resource.Description;
                dbContext.Hair.Add(hair);
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

        public bool HairExists(int id)
        {
            try
            {
                return dbContext.Hair.Any(e => e.HairId == id);

            }
            catch (System.Exception)
            {

                throw;
            }       
        }

        public void UpdateHair(HairResource resource)
        {
            try
            {
                Hair hair = dbContext.Hair.Find(resource.HairId);

                dbContext.Entry(hair).State = EntityState.Modified;

                hair.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
