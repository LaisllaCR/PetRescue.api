using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Specie specie = dbContext.Specie.Find(id);
            dbContext.Specie.Remove(specie);
        }

        public Specie GetSpecieByID(int id)
        {
            return dbContext.Specie.Find(id);
        }

        public IEnumerable<Specie> GetSpecies()
        {
            return dbContext.Specie.ToList();
        }

        public void InsertSpecie(Specie specie)
        {
            dbContext.Specie.Add(specie);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public bool SpecieExists(int id)
        {
            return dbContext.Specie.Any(e => e.ID == id);
        }

        public void UpdateSpecie(Specie specie)
        {
            dbContext.Entry(specie).State = EntityState.Modified;
        }
    }
}
