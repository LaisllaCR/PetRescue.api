using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class SizeRepository : Repository<Size>, ISizeRepository
    {
        public SizeRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteSize(int id)
        {
            Size specie = dbContext.Size.Find(id);
            dbContext.Size.Remove(specie);
        }

        public Size GetSizeByID(int id)
        {
            return dbContext.Size.Find(id);
        }

        public IEnumerable<Size> GetSizes()
        {
            return dbContext.Size.ToList();
        }

        public void InsertSize(Size specie)
        {
            dbContext.Size.Add(specie);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public bool SizeExists(int id)
        {
            return dbContext.Size.Any(e => e.SizeId == id);
        }

        public void UpdateSize(Size specie)
        {
            dbContext.Entry(specie).State = EntityState.Modified;
        }
    }
}
