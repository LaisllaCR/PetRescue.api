using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class PetRepository :  IPetRepository
    {
        private readonly dbContext _context;

        public PetRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeletePet(int id)
        {
            try
            {
                Pet pet = _context.Pet.Find(id);
                _context.Pet.Remove(pet);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public PetDto GetPetByID(int id)
        {
            try
            {
                return new PetDto(_context.Pet.Find(id));

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<PetDto> GetPets()
        {
            try
            {
                return (from pet in _context.Pet select new PetDto(pet)).ToList();

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertPet(PetDto resource)
        {
            try
            {
                if (_context.Specie.Find(resource.SpecieId) == null)
                {
                    throw new System.Exception("Specie not found");
                }
                if (_context.Breed.Find(resource.BreedId) == null)
                {
                    throw new System.Exception("Breed not found");
                }
                if (_context.Size.Find(resource.SizeId) == null)
                {
                    throw new System.Exception("Size not found");
                }
                if (_context.Age.Find(resource.AgeId) == null)
                {
                    throw new System.Exception("Age not found");
                }
                if (_context.Hair.Find(resource.HairId) == null)
                {
                    throw new System.Exception("Hair not found");
                }

                Pet pet = new Pet();
                pet.SizeId = resource.SizeId;
                pet.BreedId = resource.BreedId;
                pet.Gender = resource.Gender;
                pet.AgeId = resource.AgeId;
                pet.HairId = resource.HairId;
                pet.SpecieId = resource.SpecieId;
                pet.SpecialNeeds = resource.SpecialNeeds;
                pet.Neuter = resource.Neuter;
                pet.Vaccine = resource.Vaccine;
                pet.Story = resource.Story;
                pet.Leash = resource.Leash;
                pet.LeashDescription = resource.LeashDescription;
                pet.Chip = resource.Chip;
                pet.Weight = resource.Weight;
                pet.Name = resource.Name;

                _context.Pet.Add(pet);
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

        public bool PetExists(int id)
        {
            try
            {
                return _context.Pet.Any(e => e.PetId == id);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void UpdatePet(PetDto resource)
        {
            try
            {
                Pet pet = _context.Pet.Find(resource.PetId);

                _context.Entry(pet).State = EntityState.Modified;

                if (_context.Specie.Find(resource.SpecieId) == null)
                {
                    throw new System.Exception("Specie not found");
                }
                if (_context.Breed.Find(resource.BreedId) == null)
                {
                    throw new System.Exception("Breed not found");
                }
                if (_context.Size.Find(resource.SizeId) == null)
                {
                    throw new System.Exception("Size not found");
                }
                if (_context.Age.Find(resource.AgeId) == null)
                {
                    throw new System.Exception("Age not found");
                }
                if (_context.Hair.Find(resource.HairId) == null)
                {
                    throw new System.Exception("Hair not found");
                }

                pet.SizeId = resource.SizeId;
                pet.BreedId = resource.BreedId;
                pet.Gender = resource.Gender;
                pet.AgeId = resource.AgeId;
                pet.HairId = resource.HairId;
                pet.SpecieId = resource.SpecieId;
                pet.SpecialNeeds = resource.SpecialNeeds;
                pet.Neuter = resource.Neuter;
                pet.Vaccine = resource.Vaccine;
                pet.Story = resource.Story;
                pet.Leash = resource.Leash;
                pet.LeashDescription = resource.LeashDescription;
                pet.Chip = resource.Chip;
                pet.Weight = resource.Weight;
                pet.Name = resource.Name;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
