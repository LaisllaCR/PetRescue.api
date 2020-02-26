using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class SpecieRepository : Repository<Specie>, ISpecieRepository
    {
        public SpecieRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteSpecie(int id)
        {
            try
            {
                Specie specie = dbContext.Specie.Find(id);
                dbContext.Specie.Remove(specie);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public SpecieResource GetSpecieByID(int id)
        {
            try
            {
                return new SpecieResource(dbContext.Specie.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }       
        }

        public IEnumerable<SpecieResource> GetSpecies()
        {
            try
            {
                return (from specie in dbContext.Specie select new SpecieResource(specie)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }       
        }

        public void InsertSpecie(SpecieResource resource)
        {
            try
            {
                Specie specie = new Specie();
                specie.SpecieId = resource.SpecieId;
                specie.Description = resource.Description;

                dbContext.Specie.Add(specie);
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

        public bool SpecieExists(int id)
        {
            try
            {
                return dbContext.Specie.Any(e => e.SpecieId == id);

            }
            catch (System.Exception)
            {

                throw;
            }      
        }

        public void UpdateSpecie(SpecieResource resource)
        {
            try
            {
                Specie specie = dbContext.Specie.Find(resource.SpecieId);

                dbContext.Entry(specie).State = EntityState.Modified;

                specie.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}