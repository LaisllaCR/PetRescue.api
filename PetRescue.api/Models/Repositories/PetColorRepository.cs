using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class PetColorRepository : IPetColorRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public PetColorRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeletePetColor(int id)
        {
            try
            {
                PetColor petColor = _context.PetColor.Find(id);
                _context.PetColor.Remove(petColor);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public PetColorDto GetPetColorByID(int id)
        {
            try
            {
                PetColor petColor = _context.PetColor.Find(id);
                return _mapper.Map<PetColorDto>(petColor);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }        
        }

        public IEnumerable<PetColorDto> GetPetColors()
        {
            try
            {
                List<PetColor> allPetColors = _context.PetColor.OrderBy(x => x.PetColorId).ToList();

                List<PetColorDto> allPetColorsDtos = _mapper.Map<List<PetColor>, List<PetColorDto>>(allPetColors);

                return allPetColorsDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }        
        }

        public void InsertPetColor(PetColorDto resource)
        {
            try
            {
                PetColor petColor = new PetColor();
                petColor.PetColorId = resource.PetColorId;

                _context.PetColor.Add(petColor);
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

        public bool PetColorExists(int id)
        {
            try
            {
                return _context.PetColor.Any(e => e.PetColorId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }        
        }

        public void UpdatePetColor(PetColorDto resource)
        {
            try
            {
                PetColor petColor = _context.PetColor.Find(resource.PetColorId);

                _context.Entry(petColor).State = EntityState.Modified;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
