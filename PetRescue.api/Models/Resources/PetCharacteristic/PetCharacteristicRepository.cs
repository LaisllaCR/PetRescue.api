using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class PetCharacteristicRepository : Repository<PetCharacteristic>, IPetCharacteristicRepository
    {
        public PetCharacteristicRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeletePetCharacteristic(int id)
        {
            try
            {
                PetCharacteristic petCharacteristic = dbContext.PetCharacteristic.Find(id);
                dbContext.PetCharacteristic.Remove(petCharacteristic);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public PetCharacteristicResource GetPetCharacteristicByID(int id)
        {
            try
            {
                return new PetCharacteristicResource(dbContext.PetCharacteristic.Find(id));

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<PetCharacteristicResource> GetPetCharacteristics()
        {
            try
            {
                return (from petCharacteristic in dbContext.PetCharacteristic select new PetCharacteristicResource(petCharacteristic)).ToList();

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertPetCharacteristic(PetCharacteristicResource resource)
        {
            try
            {
                if (dbContext.Characteristics.Find(resource.CharacteristicId) == null)
                {
                    throw new System.Exception("Characteristic not found");
                }
                if (dbContext.Pet.Find(resource.PetId) == null)
                {
                    throw new System.Exception("Pet not found");
                }

                PetCharacteristic petCharacteristic = new PetCharacteristic();
                petCharacteristic.PetId = resource.PetId;
                petCharacteristic.CharacteristicId = resource.CharacteristicId;

                dbContext.PetCharacteristic.Add(petCharacteristic);
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

        public bool PetCharacteristicExists(int id)
        {
            try
            {
                return dbContext.PetCharacteristic.Any(e => e.PetCharacteristicId == id);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void UpdatePetCharacteristic(PetCharacteristicResource resource)
        {
            try
            {
                PetCharacteristic petCharacteristic = dbContext.PetCharacteristic.Find(resource.PetCharacteristicId);

                dbContext.Entry(petCharacteristic).State = EntityState.Modified;

                if (dbContext.Characteristics.Find(resource.CharacteristicId) == null)
                {
                    throw new System.Exception("Characteristic not found");
                }
                if (dbContext.Pet.Find(resource.PetId) == null)
                {
                    throw new System.Exception("Pet not found");
                }

                petCharacteristic.PetId = resource.PetId;
                petCharacteristic.CharacteristicId = resource.CharacteristicId;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}