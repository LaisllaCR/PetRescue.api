using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly dbContext _context;

        public ColorRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteColor(int id)
        {
            try
            {
                Color color = _context.Color.Find(id);
                _context.Color.Remove(color);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ColorDto GetColorByID(int id)
        {
            try
            {
                return new ColorDto(_context.Color.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }        
        }

        public IEnumerable<ColorDto> GetColors()
        {
            try
            {
                return (from color in _context.Color select new ColorDto(color)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }      
        }

        public void InsertColor(ColorDto resource)
        {
            try
            {
                Color color = new Color();
                color.ColorId = resource.ColorId;
                color.Description = resource.Description;

                _context.Color.Add(color);
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

        public bool ColorExists(int id)
        {
            try
            {
                return _context.Color.Any(e => e.ColorId == id);

            }
            catch (System.Exception)
            {

                throw;
            }     
        }

        public void UpdateColor(ColorDto resource)
        {
            try
            {
                Color color = _context.Color.Find(resource.ColorId);

                _context.Entry(color).State = EntityState.Modified;

                color.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
