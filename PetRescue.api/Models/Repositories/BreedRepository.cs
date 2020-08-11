using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class BreedRepository : Repository<Breed>, IBreedRepository
    {
        public BreedRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteBreed(int id)
        {
            try
            {
                Breed breed = dbContext.Breed.Find(id);
                dbContext.Breed.Remove(breed);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public BreedDto GetBreedByID(int id)
        {
            try
            {
                return new BreedDto(dbContext.Breed.Find(id));

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<BreedDto> GetBreeds()
        {
            try
            {
                return (from breed in dbContext.Breed select new BreedDto(breed)).ToList();

            }
            catch (System.Exception)
            {
                throw;
            }        
        }

        public void InsertBreed(BreedDto resource)
        {
            try
            {
                if (dbContext.Specie.Find(resource.SpecieId) == null)
                {
                    throw new System.Exception("Specie not found");
                }

                Breed breed = new Breed();
                breed.Description = resource.Description;
                breed.SpecieId = resource.SpecieId;

                dbContext.Breed.Add(breed);
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

        public bool BreedExists(int id)
        {
            try
            {
                return dbContext.Breed.Any(e => e.BreedId == id);

            }
            catch (System.Exception)
            {
                throw;
            }       
        }

        public void UpdateBreed(BreedDto resource)
        {
            try
            {
                Breed breed = dbContext.Breed.Find(resource.BreedId);

                dbContext.Entry(breed).State = EntityState.Modified;

                if (dbContext.Specie.Find(resource.SpecieId) == null)
                {
                    throw new System.Exception("Specie not found");
                }

                breed.Description = resource.Description;
                breed.SpecieId = resource.SpecieId;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
