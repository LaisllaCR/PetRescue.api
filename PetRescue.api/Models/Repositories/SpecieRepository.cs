using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class SpecieRepository : ISpecieRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public SpecieRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteSpecie(int id)
        {
            try
            {
                Specie specie = _context.Specie.Find(id);
                _context.Specie.Remove(specie);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public SpecieDto GetSpecieByID(int id)
        {
            try
            {
                Specie specie = _context.Specie.Find(id);
                return _mapper.Map<SpecieDto>(specie);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }       
        }

        public IEnumerable<SpecieDto> GetSpecies()
        {
            try
            {
                List<Specie> allSpecies = _context.Specie.OrderBy(x => x.Description).ToList();

                List<SpecieDto> allSpeciesDtos = _mapper.Map<List<Specie>, List<SpecieDto>>(allSpecies);

                return allSpeciesDtos; 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
        }

        public void InsertSpecie(SpecieDto resource)
        {
            try
            {
                Specie specie = new Specie();
                specie.SpecieId = resource.SpecieId;
                specie.Description = resource.Description;

                _context.Specie.Add(specie);
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

        public bool SpecieExists(int id)
        {
            try
            {
                return _context.Specie.Any(e => e.SpecieId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }      
        }

        public void UpdateSpecie(SpecieDto resource)
        {
            try
            {
                Specie specie = _context.Specie.Find(resource.SpecieId);

                _context.Entry(specie).State = EntityState.Modified;

                specie.Description = resource.Description;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}