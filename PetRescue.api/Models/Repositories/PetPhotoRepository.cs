using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class PetPhotoRepository : Repository<PetPhoto>, IPetPhotoRepository
    {
        public PetPhotoRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeletePetPhoto(int id)
        {
            try
            {
                PetPhoto specie = dbContext.PetPhoto.Find(id);
                dbContext.PetPhoto.Remove(specie);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public PetPhotoResource GetPetPhotoByID(int id)
        {
            try
            {
                return new PetPhotoResource(dbContext.PetPhoto.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<PetPhotoResource> GetPetPhotos()
        {
            try
            {
                return (from petPhoto in dbContext.PetPhoto select new PetPhotoResource(petPhoto)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertPetPhoto(PetPhotoResource resource)
        {
            try
            {
                PetPhoto petPhoto = new PetPhoto();
                petPhoto.PetPhotoId = resource.PetPhotoId;
                petPhoto.File = resource.File;
                petPhoto.PetId = resource.PetId;

                dbContext.PetPhoto.Add(petPhoto);
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

        public bool PetPhotoExists(int id)
        {
            try
            {
                return dbContext.PetPhoto.Any(e => e.PetPhotoId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdatePetPhoto(PetPhotoResource resource)
        {
            try
            {
                PetPhoto petPhoto = dbContext.PetPhoto.Find(resource.PetPhotoId);

                dbContext.Entry(petPhoto).State = EntityState.Modified;

                petPhoto.File = resource.File;
                petPhoto.PetId = resource.PetId;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
