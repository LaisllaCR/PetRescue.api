using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class ShelterRepository : Repository<Shelter>, IShelterRepository
    {
        public ShelterRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteShelter(int id)
        {
            try
            {
                Shelter shelter = dbContext.Shelter.Find(id);
                dbContext.Shelter.Remove(shelter);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ShelterResource GetShelterByID(int id)
        {
            try
            {
                return new ShelterResource(dbContext.Shelter.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<ShelterResource> GetShelters()
        {
            try
            {
                return (from shelter in dbContext.Shelter select new ShelterResource(shelter)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertShelter(ShelterResource resource)
        {
            try
            {
                Shelter shelter = new Shelter();
                shelter.ShelterId = resource.ShelterId;
                shelter.Description = resource.Description;

                dbContext.Shelter.Add(shelter);
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

        public bool ShelterExists(int id)
        {
            try
            {
                return dbContext.Shelter.Any(e => e.ShelterId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateShelter(ShelterResource resource)
        {
            try
            {
                Shelter shelter = dbContext.Shelter.Find(resource.ShelterId);

                dbContext.Entry(shelter).State = EntityState.Modified;

                shelter.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
