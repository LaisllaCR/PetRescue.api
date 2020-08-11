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
            try
            {
                Color color = dbContext.Color.Find(id);
                dbContext.Color.Remove(color);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ColorDto GetColorByID(int id)
        {
            try
            {
                return new ColorDto(dbContext.Color.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public IEnumerable<ColorDto> GetColors()
        {
            try
            {
                return (from color in dbContext.Color select new ColorDto(color)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }      
        }

        public void InsertColor(ColorDto resource)
        {
            try
            {
                Color color = new Color();
                color.ColorId = resource.ColorId;
                color.Description = resource.Description;

                dbContext.Color.Add(color);
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

        public bool ColorExists(int id)
        {
            try
            {
                return dbContext.Color.Any(e => e.ColorId == id);

            }
            catch (System.Exception)
            {

                throw;
            }     
        }

        public void UpdateColor(ColorDto resource)
        {
            try
            {
                Color color = dbContext.Color.Find(resource.ColorId);

                dbContext.Entry(color).State = EntityState.Modified;

                color.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
