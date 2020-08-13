using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class SpecieRepository : ISpecieRepository
    {
        private readonly dbContext _context;

        public SpecieRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteSpecie(int id)
        {
            try
            {
                Specie specie = _context.Specie.Find(id);
                _context.Specie.Remove(specie);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public SpecieDto GetSpecieByID(int id)
        {
            try
            {
                return new SpecieDto(_context.Specie.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }       
        }

        public IEnumerable<SpecieDto> GetSpecies()
        {
            try
            {
                List<SpecieDto> allSpecies = (from specie in _context.Specie select new SpecieDto(specie)).ToList();
                return allSpecies;

            }
            catch (Exception ex)
            {
                throw;
            }       
        }

        public void InsertSpecie(SpecieDto resource)
        {
            try
            {
                Specie specie = new Specie();
                specie.SpecieId = resource.SpecieId;
                specie.Description = resource.Description;

                _context.Specie.Add(specie);
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

        public bool SpecieExists(int id)
        {
            try
            {
                return _context.Specie.Any(e => e.SpecieId == id);

            }
            catch (System.Exception)
            {

                throw;
            }      
        }

        public void UpdateSpecie(SpecieDto resource)
        {
            try
            {
                Specie specie = _context.Specie.Find(resource.SpecieId);

                _context.Entry(specie).State = EntityState.Modified;

                specie.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}