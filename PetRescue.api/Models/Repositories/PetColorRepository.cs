using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class PetColorRepository : Repository<PetColor>, IPetColorRepository
    {
        public PetColorRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeletePetColor(int id)
        {
            try
            {
                PetColor petColor = dbContext.PetColor.Find(id);
                dbContext.PetColor.Remove(petColor);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public PetColorDto GetPetColorByID(int id)
        {
            try
            {
                return new PetColorDto(dbContext.PetColor.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public IEnumerable<PetColorDto> GetPetColors()
        {
            try
            {
                return (from petColor in dbContext.PetColor select new PetColorDto(petColor)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public void InsertPetColor(PetColorDto resource)
        {
            try
            {
                PetColor petColor = new PetColor();
                petColor.PetColorId = resource.PetColorId;

                dbContext.PetColor.Add(petColor);
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

        public bool PetColorExists(int id)
        {
            try
            {
                return dbContext.PetColor.Any(e => e.PetColorId == id);

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public void UpdatePetColor(PetColorDto resource)
        {
            try
            {
                PetColor petColor = dbContext.PetColor.Find(resource.PetColorId);

                dbContext.Entry(petColor).State = EntityState.Modified;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
