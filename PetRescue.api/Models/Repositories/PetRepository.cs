using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        public PetRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeletePet(int id)
        {
            try
            {
                Pet pet = dbContext.Pet.Find(id);
                dbContext.Pet.Remove(pet);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public PetResource GetPetByID(int id)
        {
            try
            {
                return new PetResource(dbContext.Pet.Find(id));

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<PetResource> GetPets()
        {
            try
            {
                return (from pet in dbContext.Pet select new PetResource(pet)).ToList();

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertPet(PetResource resource)
        {
            try
            {
                if (dbContext.Specie.Find(resource.SpecieId) == null)
                {
                    throw new System.Exception("Specie not found");
                }
                if (dbContext.Breed.Find(resource.BreedId) == null)
                {
                    throw new System.Exception("Breed not found");
                }
                if (dbContext.Size.Find(resource.SizeId) == null)
                {
                    throw new System.Exception("Size not found");
                }
                if (dbContext.Age.Find(resource.AgeId) == null)
                {
                    throw new System.Exception("Age not found");
                }
                if (dbContext.Hair.Find(resource.HairId) == null)
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

                dbContext.Pet.Add(pet);
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

        public bool PetExists(int id)
        {
            try
            {
                return dbContext.Pet.Any(e => e.PetId == id);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void UpdatePet(PetResource resource)
        {
            try
            {
                Pet pet = dbContext.Pet.Find(resource.PetId);

                dbContext.Entry(pet).State = EntityState.Modified;

                if (dbContext.Specie.Find(resource.SpecieId) == null)
                {
                    throw new System.Exception("Specie not found");
                }
                if (dbContext.Breed.Find(resource.BreedId) == null)
                {
                    throw new System.Exception("Breed not found");
                }
                if (dbContext.Size.Find(resource.SizeId) == null)
                {
                    throw new System.Exception("Size not found");
                }
                if (dbContext.Age.Find(resource.AgeId) == null)
                {
                    throw new System.Exception("Age not found");
                }
                if (dbContext.Hair.Find(resource.HairId) == null)
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
