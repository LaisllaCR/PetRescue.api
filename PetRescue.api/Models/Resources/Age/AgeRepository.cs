using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class AgeRepository : Repository<Age>, IAgeRepository
    {
        public AgeRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteAge(int id)
        {
            try
            {
                Age age = dbContext.Age.Find(id);
                dbContext.Age.Remove(age);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public AgeResource GetAgeByID(int id)
        {
            try
            {
                return new AgeResource(dbContext.Age.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public IEnumerable<AgeResource> GetAges()
        {
            try
            {
                return (from age in dbContext.Age select new AgeResource(age)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public void InsertAge(AgeResource resource)
        {
            try
            {
                Age age = new Age();
                age.AgeId = resource.AgeId;
                age.Description = resource.Description;

                dbContext.Age.Add(age);
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

        public bool AgeExists(int id)
        {
            try
            {
                return dbContext.Age.Any(e => e.AgeId == id);

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public void UpdateAge(AgeResource resource)
        {
            try
            {
                Age age = dbContext.Age.Find(resource.AgeId);

                dbContext.Entry(age).State = EntityState.Modified;

                age.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
