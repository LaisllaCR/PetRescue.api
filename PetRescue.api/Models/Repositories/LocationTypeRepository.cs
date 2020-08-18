using AutoMapper;
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
        private readonly IMapper _mapper;

        public LocationTypeRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteLocationType(int id)
        {
            try
            {
                LocationType locationType = _context.LocationType.Find(id);
                _context.LocationType.Remove(locationType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LocationTypeDto GetLocationTypeByID(int id)
        {
            try
            {
                LocationType locationType = _context.LocationType.Find(id);
                return _mapper.Map<LocationTypeDto>(locationType);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<LocationTypeDto> GetLocationTypes()
        {
            try
            {
                List<LocationType> allLocationTypes = _context.LocationType.OrderBy(x => x.Description).ToList();

                List<LocationTypeDto> allLocationTypesDtos = _mapper.Map<List<LocationType>, List<LocationTypeDto>>(allLocationTypes);

                return allLocationTypesDtos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool LocationTypeExists(int id)
        {
            try
            {
                return _context.LocationType.Any(e => e.LocationTypeId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}