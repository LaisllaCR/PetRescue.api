using AutoMapper;
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
        private readonly IMapper _mapper;

        public ColorRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteColor(int id)
        {
            try
            {
                Color color = _context.Color.Find(id);
                _context.Color.Remove(color);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ColorDto GetColorByID(int id)
        {
            try
            {
                Color color = _context.Color.Find(id);
                return _mapper.Map<ColorDto>(color);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }        
        }

        public IEnumerable<ColorDto> GetColors()
        {
            try
            {
                List<Color> allColors = _context.Color.OrderBy(x => x.Description).ToList();

                List<ColorDto> allColorsDtos = _mapper.Map<List<Color>, List<ColorDto>>(allColors);

                return allColorsDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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

        public bool ColorExists(int id)
        {
            try
            {
                return _context.Color.Any(e => e.ColorId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
