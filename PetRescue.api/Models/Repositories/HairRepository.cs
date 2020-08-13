using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class HairRepository : IHairRepository
    {
        private readonly dbContext _context;

        public HairRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteHair(int id)
        {
            try
            {
                Hair hair = _context.Hair.Find(id);
                _context.Hair.Remove(hair);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public HairDto GetHairByID(int id)
        {
            try
            {
                return new HairDto(_context.Hair.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }     
        }

        public IEnumerable<HairDto> GetHairs()
        {
            try
            {
                return (from hair in _context.Hair select new HairDto(hair)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }    
        }

        public void InsertHair(HairDto resource)
        {
            try
            {
                Hair hair = new Hair();
                hair.HairId = resource.HairId;
                hair.Description = resource.Description;
                _context.Hair.Add(hair);
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

        public bool HairExists(int id)
        {
            try
            {
                return _context.Hair.Any(e => e.HairId == id);

            }
            catch (System.Exception)
            {

                throw;
            }       
        }

        public void UpdateHair(HairDto resource)
        {
            try
            {
                Hair hair = _context.Hair.Find(resource.HairId);

                _context.Entry(hair).State = EntityState.Modified;

                hair.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
