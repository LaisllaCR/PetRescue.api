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
    public class ShelterRepository : IShelterRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public ShelterRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteShelter(int id)
        {
            try
            {
                Shelter shelter = _context.Shelter.Find(id);
                _context.Shelter.Remove(shelter);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ShelterDto GetShelterByID(int id)
        {
            try
            {
                Shelter shelter = _context.Shelter.Find(id);
                return _mapper.Map<ShelterDto>(shelter);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ShelterDto> GetShelters()
        {
            try
            {
                List<Shelter> allShelters = _context.Shelter.OrderBy(x => x.Description).ToList();

                List<ShelterDto> allSheltersDtos = _mapper.Map<List<Shelter>, List<ShelterDto>>(allShelters);

                return allSheltersDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertShelter(ShelterDto resource)
        {
            try
            {
                Shelter shelter = new Shelter();
                shelter.ShelterId = resource.ShelterId;
                shelter.Description = resource.Description;

                _context.Shelter.Add(shelter);
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

        public bool ShelterExists(int id)
        {
            try
            {
                return _context.Shelter.Any(e => e.ShelterId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateShelter(ShelterDto resource)
        {
            try
            {
                Shelter shelter = _context.Shelter.Find(resource.ShelterId);

                _context.Entry(shelter).State = EntityState.Modified;

                shelter.Description = resource.Description;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
