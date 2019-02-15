using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Age specie = dbContext.Age.Find(id);
            dbContext.Age.Remove(specie);
        }

        public Age GetAgeByID(int id)
        {
            return dbContext.Age.Find(id);
        }

        public IEnumerable<Age> GetAges()
        {
            return dbContext.Age.ToList();
        }

        public void InsertAge(Age specie)
        {
            dbContext.Age.Add(specie);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public bool AgeExists(int id)
        {
            return dbContext.Age.Any(e => e.ID == id);
        }

        public void UpdateAge(Age specie)
        {
            dbContext.Entry(specie).State = EntityState.Modified;
        }
    }
}
