using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class CharacteristicRepository : Repository<Characteristics>, ICharacteristicRepository
    {
        public CharacteristicRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteCharacteristic(int id)
        {
            try
            {
                Characteristics characteristic = dbContext.Characteristics.Find(id);
                dbContext.Characteristics.Remove(characteristic);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public CharacteristicResource GetCharacteristicByID(int id)
        {
            try
            {
                return new CharacteristicResource(dbContext.Characteristics.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<CharacteristicResource> GetCharacteristics()
        {
            try
            {
                return (from characteristic in dbContext.Characteristics select new CharacteristicResource(characteristic)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertCharacteristic(CharacteristicResource resource)
        {
            try
            {
                Characteristics characteristic = new Characteristics();
                characteristic.CharacteristicId = resource.CharacteristicId;
                characteristic.Description = resource.Description;
                dbContext.Characteristics.Add(characteristic);
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

        public bool CharacteristicExists(int id)
        {
            try
            {
                return dbContext.Characteristics.Any(e => e.CharacteristicId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateCharacteristic(CharacteristicResource resource)
        {
            try
            {
                Characteristics characteristic = dbContext.Characteristics.Find(resource.CharacteristicId);

                dbContext.Entry(characteristic).State = EntityState.Modified;

                characteristic.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
