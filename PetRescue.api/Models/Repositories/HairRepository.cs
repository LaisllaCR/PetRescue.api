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
            Hair specie = dbContext.Hair.Find(id);
            dbContext.Hair.Remove(specie);
        }

        public Hair GetHairByID(int id)
        {
            return dbContext.Hair.Find(id);
        }

        public IEnumerable<Hair> GetHairs()
        {
            return dbContext.Hair.ToList();
        }

        public void InsertHair(Hair specie)
        {
            dbContext.Hair.Add(specie);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public bool HairExists(int id)
        {
            return dbContext.Hair.Any(e => e.HairId == id);
        }

        public void UpdateHair(Hair specie)
        {
            dbContext.Entry(specie).State = EntityState.Modified;
        }
    }
}
