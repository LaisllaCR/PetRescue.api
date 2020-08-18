using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class AgeRepository : IAgeRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public AgeRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteAge(int id)
        {
            try
            {
                Age age = _context.Age.Find(id);
                _context.Age.Remove(age);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public AgeDto GetAgeByID(int id)
        {
            try
            {
                Age age = _context.Age.Find(id);
                return _mapper.Map<AgeDto>(age);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }        
        }

        public IEnumerable<AgeDto> GetAges()
        {
            try
            {
                List<Age> allAges = _context.Age.OrderBy(x => x.Description).ToList();

                List<AgeDto> allAgesDtos = _mapper.Map<List<Age>, List<AgeDto>>(allAges);

                return allAgesDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }        
        }

        public void InsertAge(AgeDto resource)
        {
            try
            {
                Age age = new Age();
                age.AgeId = resource.AgeId;
                age.Description = resource.Description;

                _context.Age.Add(age);
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

        public bool AgeExists(int id)
        {
            try
            {
                return _context.Age.Any(e => e.AgeId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }        
        }

        public void UpdateAge(AgeDto resource)
        {
            try
            {
                Age age = _context.Age.Find(resource.AgeId);

                _context.Entry(age).State = EntityState.Modified;

                age.Description = resource.Description;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
