using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class LocationTypeRepository : ILocationTypeRepository
    {
        private readonly dbContext _context;

        public LocationTypeRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteLocationType(int id)
        {
            try
            {
                LocationType locationType = _context.LocationType.Find(id);
                _context.LocationType.Remove(locationType);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public LocationTypeDto GetLocationTypeByID(int id)
        {
            try
            {
                return new LocationTypeDto(_context.LocationType.Find(id));

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<LocationTypeDto> GetLocationTypes()
        {
            try
            {
                return (from locationType in _context.LocationType select new LocationTypeDto(locationType)).ToList();

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertLocationType(LocationTypeDto resource)
        {
            try
            {
                LocationType locationType = new LocationType();
                locationType.Description = resource.Description;

                _context.LocationType.Add(locationType);
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
                _context.SaveChanges();

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
                return _context.LocationType.Any(e => e.LocationTypeId == id);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void UpdateLocationType(LocationTypeDto resource)
        {
            try
            {
                LocationType locationType = _context.LocationType.Find(resource.LocationTypeId);

                _context.Entry(locationType).State = EntityState.Modified;
                
                locationType.Description = resource.Description;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}