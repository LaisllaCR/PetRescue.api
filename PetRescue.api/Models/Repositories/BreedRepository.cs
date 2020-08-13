using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly dbContext _context;

        public BreedRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteBreed(int id)
        {
            try
            {
                Breed breed = _context.Breed.Find(id);
                _context.Breed.Remove(breed);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public BreedDto GetBreedByID(int id)
        {
            try
            {
                return new BreedDto(_context.Breed.Find(id));

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<BreedDto> GetBreeds()
        {
            try
            {
                return (from breed in _context.Breed select new BreedDto(breed)).ToList();

            }
            catch (System.Exception)
            {
                throw;
            }        
        }

        public void InsertBreed(BreedDto resource)
        {
            try
            {
                if (_context.Specie.Find(resource.SpecieId) == null)
                {
                    throw new System.Exception("Specie not found");
                }

                Breed breed = new Breed();
                breed.Description = resource.Description;
                breed.SpecieId = resource.SpecieId;

                _context.Breed.Add(breed);
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

        public bool BreedExists(int id)
        {
            try
            {
                return _context.Breed.Any(e => e.BreedId == id);

            }
            catch (System.Exception)
            {
                throw;
            }       
        }

        public void UpdateBreed(BreedDto resource)
        {
            try
            {
                Breed breed = _context.Breed.Find(resource.BreedId);

                _context.Entry(breed).State = EntityState.Modified;

                if (_context.Specie.Find(resource.SpecieId) == null)
                {
                    throw new System.Exception("Specie not found");
                }

                breed.Description = resource.Description;
                breed.SpecieId = resource.SpecieId;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
