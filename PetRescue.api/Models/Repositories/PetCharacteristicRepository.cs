using AutoMapper;
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
        private readonly IMapper _mapper;

        public PetCharacteristicRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeletePetCharacteristic(int id)
        {
            try
            {
                PetCharacteristic petCharacteristic = _context.PetCharacteristic.Find(id);
                _context.PetCharacteristic.Remove(petCharacteristic);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PetCharacteristicDto GetPetCharacteristicByID(int id)
        {
            try
            {
                PetCharacteristic petCharacteristic = _context.PetCharacteristic.Find(id);
                return _mapper.Map<PetCharacteristicDto>(petCharacteristic);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PetCharacteristicDto> GetPetCharacteristics()
        {
            try
            {
                List<PetCharacteristic> allPetCharacteristics = _context.PetCharacteristic.OrderBy(x => x.PetCharacteristicId).ToList();

                List<PetCharacteristicDto> allPetCharacteristicsDtos = _mapper.Map<List<PetCharacteristic>, List<PetCharacteristicDto>>(allPetCharacteristics);

                return allPetCharacteristicsDtos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertPetCharacteristic(PetCharacteristicDto resource)
        {
            try
            {
                if (_context.Characteristic.Find(resource.CharacteristicId) == null)
                {
                    throw new Exception("Characteristic not found");
                }
                if (_context.Pet.Find(resource.PetId) == null)
                {
                    throw new Exception("Pet not found");
                }

                PetCharacteristic petCharacteristic = new PetCharacteristic();
                petCharacteristic.PetId = resource.PetId;
                petCharacteristic.CharacteristicId = resource.CharacteristicId;

                _context.PetCharacteristic.Add(petCharacteristic);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool PetCharacteristicExists(int id)
        {
            try
            {
                return _context.PetCharacteristic.Any(e => e.PetCharacteristicId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePetCharacteristic(PetCharacteristicDto resource)
        {
            try
            {
                PetCharacteristic petCharacteristic = _context.PetCharacteristic.Find(resource.PetCharacteristicId);

                _context.Entry(petCharacteristic).State = EntityState.Modified;

                if (_context.Characteristic.Find(resource.CharacteristicId) == null)
                {
                    throw new Exception("Characteristic not found");
                }
                if (_context.Pet.Find(resource.PetId) == null)
                {
                    throw new Exception("Pet not found");
                }

                petCharacteristic.PetId = resource.PetId;
                petCharacteristic.CharacteristicId = resource.CharacteristicId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}