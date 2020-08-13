using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class PetCharacteristicRepository : IPetCharacteristicRepository
    {
        private readonly dbContext _context;

        public PetCharacteristicRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeletePetCharacteristic(int id)
        {
            try
            {
                PetCharacteristic petCharacteristic = _context.PetCharacteristic.Find(id);
                _context.PetCharacteristic.Remove(petCharacteristic);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public PetCharacteristicDto GetPetCharacteristicByID(int id)
        {
            try
            {
                return new PetCharacteristicDto(_context.PetCharacteristic.Find(id));

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<PetCharacteristicDto> GetPetCharacteristics()
        {
            try
            {
                return (from petCharacteristic in _context.PetCharacteristic select new PetCharacteristicDto(petCharacteristic)).ToList();

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertPetCharacteristic(PetCharacteristicDto resource)
        {
            try
            {
                if (_context.Characteristics.Find(resource.CharacteristicId) == null)
                {
                    throw new System.Exception("Characteristic not found");
                }
                if (_context.Pet.Find(resource.PetId) == null)
                {
                    throw new System.Exception("Pet not found");
                }

                PetCharacteristic petCharacteristic = new PetCharacteristic();
                petCharacteristic.PetId = resource.PetId;
                petCharacteristic.CharacteristicId = resource.CharacteristicId;

                _context.PetCharacteristic.Add(petCharacteristic);
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

        public bool PetCharacteristicExists(int id)
        {
            try
            {
                return _context.PetCharacteristic.Any(e => e.PetCharacteristicId == id);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void UpdatePetCharacteristic(PetCharacteristicDto resource)
        {
            try
            {
                PetCharacteristic petCharacteristic = _context.PetCharacteristic.Find(resource.PetCharacteristicId);

                _context.Entry(petCharacteristic).State = EntityState.Modified;

                if (_context.Characteristics.Find(resource.CharacteristicId) == null)
                {
                    throw new System.Exception("Characteristic not found");
                }
                if (_context.Pet.Find(resource.PetId) == null)
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