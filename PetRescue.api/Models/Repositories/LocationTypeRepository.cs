using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class LocationTypeRepository : Repository<LocationType>, ILocationTypeRepository
    {
        public LocationTypeRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteLocationType(int id)
        {
            try
            {
                LocationType locationType = dbContext.LocationType.Find(id);
                dbContext.LocationType.Remove(locationType);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public LocationTypeResource GetLocationTypeByID(int id)
        {
            try
            {
                return new LocationTypeResource(dbContext.LocationType.Find(id));

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<LocationTypeResource> GetLocationTypes()
        {
            try
            {
                return (from locationType in dbContext.LocationType select new LocationTypeResource(locationType)).ToList();

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertLocationType(LocationTypeResource resource)
        {
            try
            {
                LocationType locationType = new LocationType();
                locationType.Description = resource.Description;

                dbContext.LocationType.Add(locationType);
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

        public bool LocationTypeExists(int id)
        {
            try
            {
                return dbContext.LocationType.Any(e => e.LocationTypeId == id);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void UpdateLocationType(LocationTypeResource resource)
        {
            try
            {
                LocationType locationType = dbContext.LocationType.Find(resource.LocationTypeId);

                dbContext.Entry(locationType).State = EntityState.Modified;
                
                locationType.Description = resource.Description;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}