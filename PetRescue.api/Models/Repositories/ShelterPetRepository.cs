using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class ShelterPetRepository : IShelterPetRepository
    {
        private readonly dbContext _context;

        public ShelterPetRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteShelterPet(int id)
        {
            try
            {
                ShelterPet shelterPet = _context.ShelterPet.Find(id);
                _context.ShelterPet.Remove(shelterPet);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ShelterPetDto GetShelterPetByID(int id)
        {
            try
            {
                return new ShelterPetDto(_context.ShelterPet.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<ShelterPetDto> GetShelterPets()
        {
            try
            {
                return (from shelterPet in _context.ShelterPet select new ShelterPetDto(shelterPet)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertShelterPet(ShelterPetDto resource)
        {
            try
            {
                ShelterPet shelterPet = new ShelterPet();
                shelterPet.ShelterPetId = resource.ShelterPetId;
                _context.ShelterPet.Add(shelterPet);
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

        public bool ShelterPetExists(int id)
        {
            try
            {
                return _context.ShelterPet.Any(e => e.ShelterPetId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateShelterPet(ShelterPetDto resource)
        {
            try
            {
                ShelterPet shelterPet = _context.ShelterPet.Find(resource.ShelterPetId);

                _context.Entry(shelterPet).State = EntityState.Modified;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
