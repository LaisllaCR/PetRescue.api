using AutoMapper;
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
        private readonly IMapper _mapper;

        public PetPhotoRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeletePetPhoto(int id)
        {
            try
            {
                PetPhoto petPhoto = _context.PetPhoto.Find(id);
                _context.PetPhoto.Remove(petPhoto);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public PetPhotoDto GetPetPhotoByID(int id)
        {
            try
            {
                PetPhoto petPhoto = _context.PetPhoto.Find(id);
                return _mapper.Map<PetPhotoDto>(petPhoto);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PetPhotoDto> GetPetPhotos()
        {
            try
            {
                List<PetPhoto> allPetPhotos = _context.PetPhoto.OrderBy(x => x.Description).ToList();

                List<PetPhotoDto> allPetPhotosDtos = _mapper.Map<List<PetPhoto>, List<PetPhotoDto>>(allPetPhotos);

                return allPetPhotosDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertPetPhoto(PetPhotoDto resource)
        {
            try
            {
                PetPhoto petPhoto = new PetPhoto();
                petPhoto.PetPhotoId = resource.PetPhotoId;
                petPhoto.FileUrl = resource.File;
                petPhoto.PetId = resource.PetId;

                _context.PetPhoto.Add(petPhoto);
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

        public bool PetPhotoExists(int id)
        {
            try
            {
                return _context.PetPhoto.Any(e => e.PetPhotoId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdatePetPhoto(PetPhotoDto resource)
        {
            try
            {
                PetPhoto petPhoto = _context.PetPhoto.Find(resource.PetPhotoId);

                _context.Entry(petPhoto).State = EntityState.Modified;

                petPhoto.FileUrl = resource.File;
                petPhoto.PetId = resource.PetId;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
