using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteColor(int id)
        {
            Color specie = dbContext.Color.Find(id);
            dbContext.Color.Remove(specie);
        }

        public Color GetColorByID(int id)
        {
            return dbContext.Color.Find(id);
        }

        public IEnumerable<Color> GetColors()
        {
            return dbContext.Color.ToList();
        }

        public void InsertColor(Color specie)
        {
            dbContext.Color.Add(specie);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public bool ColorExists(int id)
        {
            return dbContext.Color.Any(e => e.ColorId == id);
        }

        public void UpdateColor(Color specie)
        {
            dbContext.Entry(specie).State = EntityState.Modified;
        }
    }
}
