using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly dbContext _context;

        public ShelterRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteShelter(int id)
        {
            try
            {
                Shelter shelter = _context.Shelter.Find(id);
                _context.Shelter.Remove(shelter);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ShelterDto GetShelterByID(int id)
        {
            try
            {
                return new ShelterDto(_context.Shelter.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<ShelterDto> GetShelters()
        {
            try
            {
                return (from shelter in _context.Shelter select new ShelterDto(shelter)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertShelter(ShelterDto resource)
        {
            try
            {
                Shelter shelter = new Shelter();
                shelter.ShelterId = resource.ShelterId;
                shelter.Description = resource.Description;

                _context.Shelter.Add(shelter);
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

        public bool ShelterExists(int id)
        {
            try
            {
                return _context.Shelter.Any(e => e.ShelterId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateShelter(ShelterDto resource)
        {
            try
            {
                Shelter shelter = _context.Shelter.Find(resource.ShelterId);

                _context.Entry(shelter).State = EntityState.Modified;

                shelter.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
