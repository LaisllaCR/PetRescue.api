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
            try
            {
                Size specie = dbContext.Size.Find(id);
                dbContext.Size.Remove(specie);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public SizeResource GetSizeByID(int id)
        {
            try
            {
                return new SizeResource(dbContext.Size.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }      
        }

        public IEnumerable<SizeResource> GetSizes()
        {
            try
            {
                return (from size in dbContext.Size select new SizeResource(size)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }    
        }

        public void InsertSize(SizeResource resource)
        {
            try
            {
                Size size = new Size();
                size.SizeId = resource.SizeId;
                size.Description = resource.Description;
                dbContext.Size.Add(size);
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

        public bool SizeExists(int id)
        {
            try
            {
                return dbContext.Size.Any(e => e.SizeId == id);

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public void UpdateSize(SizeResource resource)
        {
            try
            {
                Size size = dbContext.Size.Find(resource.SizeId);

                dbContext.Entry(size).State = EntityState.Modified;

                size.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
