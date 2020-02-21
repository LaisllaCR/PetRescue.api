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
            Breed specie = dbContext.Breed.Find(id);
            dbContext.Breed.Remove(specie);
        }

        public Breed GetBreedByID(int id)
        {
            return dbContext.Breed.Find(id);
        }

        public IEnumerable<Breed> GetBreeds()
        {
            return dbContext.Breed.ToList();
        }

        public void InsertBreed(Breed specie)
        {
            dbContext.Breed.Add(specie);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public bool BreedExists(int id)
        {
            return dbContext.Breed.Any(e => e.BreedId == id);
        }

        public void UpdateBreed(Breed specie)
        {
            dbContext.Entry(specie).State = EntityState.Modified;
        }
    }
}
