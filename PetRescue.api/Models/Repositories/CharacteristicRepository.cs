using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class CharacteristicRepository : ICharacteristicRepository
    {
        private readonly dbContext _context;

        public CharacteristicRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteCharacteristic(int id)
        {
            try
            {
                Characteristics characteristic = _context.Characteristics.Find(id);
                _context.Characteristics.Remove(characteristic);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public CharacteristicDto GetCharacteristicByID(int id)
        {
            try
            {
                return new CharacteristicDto(_context.Characteristics.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<CharacteristicDto> GetCharacteristics()
        {
            try
            {
                return (from characteristic in _context.Characteristics select new CharacteristicDto(characteristic)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertCharacteristic(CharacteristicDto resource)
        {
            try
            {
                Characteristics characteristic = new Characteristics();
                characteristic.CharacteristicId = resource.CharacteristicId;
                characteristic.Description = resource.Description;
                _context.Characteristics.Add(characteristic);
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

        public bool CharacteristicExists(int id)
        {
            try
            {
                return _context.Characteristics.Any(e => e.CharacteristicId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateCharacteristic(CharacteristicDto resource)
        {
            try
            {
                Characteristics characteristic = _context.Characteristics.Find(resource.CharacteristicId);

                _context.Entry(characteristic).State = EntityState.Modified;

                characteristic.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
