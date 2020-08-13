using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class AgeRepository : IAgeRepository
    {
        private readonly dbContext _context;

        public AgeRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteAge(int id)
        {
            try
            {
                Age age = _context.Age.Find(id);
                _context.Age.Remove(age);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public AgeDto GetAgeByID(int id)
        {
            try
            {
                return new AgeDto(_context.Age.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public IEnumerable<AgeDto> GetAges()
        {
            try
            {
                return (from age in _context.Age select new AgeDto(age)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public void InsertAge(AgeDto resource)
        {
            try
            {
                Age age = new Age();
                age.AgeId = resource.AgeId;
                age.Description = resource.Description;

                _context.Age.Add(age);
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

        public bool AgeExists(int id)
        {
            try
            {
                return _context.Age.Any(e => e.AgeId == id);

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public void UpdateAge(AgeDto resource)
        {
            try
            {
                Age age = _context.Age.Find(resource.AgeId);

                _context.Entry(age).State = EntityState.Modified;

                age.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
