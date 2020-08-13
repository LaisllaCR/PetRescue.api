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

        public SizeRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteSize(int id)
        {
            try
            {
                Size size = _context.Size.Find(id);
                _context.Size.Remove(size);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public SizeDto GetSizeByID(int id)
        {
            try
            {
                return new SizeDto(_context.Size.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }      
        }

        public IEnumerable<SizeDto> GetSizes()
        {
            try
            {
                return (from size in _context.Size select new SizeDto(size)).ToList();

            }
            catch (System.Exception)
            {

                throw;
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

        public bool SizeExists(int id)
        {
            try
            {
                return _context.Size.Any(e => e.SizeId == id);

            }
            catch (System.Exception)
            {

                throw;
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
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
