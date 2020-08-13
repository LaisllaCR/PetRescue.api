using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class PetColorRepository : IPetColorRepository
    {
        private readonly dbContext _context;

        public PetColorRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeletePetColor(int id)
        {
            try
            {
                PetColor petColor = _context.PetColor.Find(id);
                _context.PetColor.Remove(petColor);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public PetColorDto GetPetColorByID(int id)
        {
            try
            {
                return new PetColorDto(_context.PetColor.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public IEnumerable<PetColorDto> GetPetColors()
        {
            try
            {
                return (from petColor in _context.PetColor select new PetColorDto(petColor)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public void InsertPetColor(PetColorDto resource)
        {
            try
            {
                PetColor petColor = new PetColor();
                petColor.PetColorId = resource.PetColorId;

                _context.PetColor.Add(petColor);
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

        public bool PetColorExists(int id)
        {
            try
            {
                return _context.PetColor.Any(e => e.PetColorId == id);

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public void UpdatePetColor(PetColorDto resource)
        {
            try
            {
                PetColor petColor = _context.PetColor.Find(resource.PetColorId);

                _context.Entry(petColor).State = EntityState.Modified;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
