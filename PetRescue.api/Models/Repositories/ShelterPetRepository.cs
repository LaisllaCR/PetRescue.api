using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class ShelterPetRepository : Repository<ShelterPet>, IShelterPetRepository
    {
        public ShelterPetRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteShelterPet(int id)
        {
            try
            {
                ShelterPet shelterPet = dbContext.ShelterPet.Find(id);
                dbContext.ShelterPet.Remove(shelterPet);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ShelterPetResource GetShelterPetByID(int id)
        {
            try
            {
                return new ShelterPetResource(dbContext.ShelterPet.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<ShelterPetResource> GetShelterPets()
        {
            try
            {
                return (from shelterPet in dbContext.ShelterPet select new ShelterPetResource(shelterPet)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertShelterPet(ShelterPetResource resource)
        {
            try
            {
                ShelterPet shelterPet = new ShelterPet();
                shelterPet.ShelterPetId = resource.ShelterPetId;
                dbContext.ShelterPet.Add(shelterPet);
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

        public bool ShelterPetExists(int id)
        {
            try
            {
                return dbContext.ShelterPet.Any(e => e.ShelterPetId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateShelterPet(ShelterPetResource resource)
        {
            try
            {
                ShelterPet shelterPet = dbContext.ShelterPet.Find(resource.ShelterPetId);

                dbContext.Entry(shelterPet).State = EntityState.Modified;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
