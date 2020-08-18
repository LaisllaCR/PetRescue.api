using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class PelageRepository : IPelageRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public PelageRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeletePelage(int id)
        {
            try
            {
                Pelage hair = _context.Pelage.Find(id);
                _context.Pelage.Remove(hair);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public PelageDto GetPelageByID(int id)
        {
            try
            {
                Pelage hair = _context.Pelage.Find(id);
                return _mapper.Map<PelageDto>(hair);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }     
        }

        public IEnumerable<PelageDto> GetPelages()
        {
            try
            {
                List<Pelage> allPelages = _context.Pelage.OrderBy(x => x.Description).ToList();

                List<PelageDto> allPelagesDtos = _mapper.Map<List<Pelage>, List<PelageDto>>(allPelages);

                return allPelagesDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }    
        }

        public void InsertPelage(PelageDto resource)
        {
            try
            {
                Pelage hair = new Pelage();
                hair.PelageId = resource.HairId;
                hair.Description = resource.Description;
                _context.Pelage.Add(hair);
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

        public bool PelageExists(int id)
        {
            try
            {
                return _context.Pelage.Any(e => e.PelageId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }       
        }

        public void UpdatePelage(PelageDto resource)
        {
            try
            {
                Pelage hair = _context.Pelage.Find(resource.HairId);

                _context.Entry(hair).State = EntityState.Modified;

                hair.Description = resource.Description;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
