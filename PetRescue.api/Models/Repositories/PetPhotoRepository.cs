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
                PetPhoto petPhoto = dbContext.PetPhoto.Find(id);
                dbContext.PetPhoto.Remove(petPhoto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public PetPhotoDto GetPetPhotoByID(int id)
        {
            try
            {
                return new PetPhotoDto(dbContext.PetPhoto.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<PetPhotoDto> GetPetPhotos()
        {
            try
            {
                return (from petPhoto in dbContext.PetPhoto select new PetPhotoDto(petPhoto)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertPetPhoto(PetPhotoDto resource)
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

        public void UpdatePetPhoto(PetPhotoDto resource)
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
