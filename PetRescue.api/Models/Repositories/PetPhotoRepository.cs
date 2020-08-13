using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class PetPhotoRepository :  IPetPhotoRepository
    {
        private readonly dbContext _context;

        public PetPhotoRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeletePetPhoto(int id)
        {
            try
            {
                PetPhoto petPhoto = _context.PetPhoto.Find(id);
                _context.PetPhoto.Remove(petPhoto);
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
                return new PetPhotoDto(_context.PetPhoto.Find(id));

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
                return (from petPhoto in _context.PetPhoto select new PetPhotoDto(petPhoto)).ToList();

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

                _context.PetPhoto.Add(petPhoto);
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

        public bool PetPhotoExists(int id)
        {
            try
            {
                return _context.PetPhoto.Any(e => e.PetPhotoId == id);

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
                PetPhoto petPhoto = _context.PetPhoto.Find(resource.PetPhotoId);

                _context.Entry(petPhoto).State = EntityState.Modified;

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
