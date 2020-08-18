using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public SizeRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteSize(int id)
        {
            try
            {
                Size size = _context.Size.Find(id);
                _context.Size.Remove(size);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public SizeDto GetSizeByID(int id)
        {
            try
            {
                Size size = _context.Size.Find(id);
                return _mapper.Map<SizeDto>(size);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }      
        }

        public IEnumerable<SizeDto> GetSizes()
        {
            try
            {
                List<Size> allSizes = _context.Size.OrderBy(x => x.Description).ToList();

                List<SizeDto> allSizesDtos = _mapper.Map<List<Size>, List<SizeDto>>(allSizes);

                return allSizesDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }    
        }

        public void InsertSize(SizeDto resource)
        {
            try
            {
                Size size = new Size();
                size.SizeId = resource.SizeId;
                size.Description = resource.Description;
                _context.Size.Add(size);
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

        public bool SizeExists(int id)
        {
            try
            {
                return _context.Size.Any(e => e.SizeId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }        
        }

        public void UpdateSize(SizeDto resource)
        {
            try
            {
                Size size = _context.Size.Find(resource.SizeId);

                _context.Entry(size).State = EntityState.Modified;

                size.Description = resource.Description;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
