using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Model.DAL.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public BreedRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteBreed(int id)
        {
            try
            {
                Breed breed = _context.Breed.Find(id);
                _context.Breed.Remove(breed);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BreedDto GetBreedByID(int id)
        {
            try
            {
                Breed breed = _context.Breed.Find(id);
                return _mapper.Map<BreedDto>(breed);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<BreedDto> GetBreeds()
        {
            try
            {
                List<Breed> allBreeds = _context.Breed.OrderBy(x => x.Description).ToList();

                List<BreedDto> allBreedsDtos = _mapper.Map<List<Breed>, List<BreedDto>>(allBreeds);

                return allBreedsDtos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }        
        }

        public void InsertBreed(BreedDto resource)
        {
            try
            {
                if (_context.Specie.Find(resource.SpecieId) == null)
                {
                    throw new Exception("Specie not found");
                }

                Breed breed = new Breed();
                breed.Description = resource.Description;
                breed.SpecieId = resource.SpecieId;

                _context.Breed.Add(breed);
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

        public bool BreedExists(int id)
        {
            try
            {
                return _context.Breed.Any(e => e.BreedId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
        }

        public void UpdateBreed(BreedDto resource)
        {
            try
            {
                Breed breed = _context.Breed.Find(resource.BreedId);

                _context.Entry(breed).State = EntityState.Modified;

                if (_context.Specie.Find(resource.SpecieId) == null)
                {
                    throw new Exception("Specie not found");
                }

                breed.Description = resource.Description;
                breed.SpecieId = resource.SpecieId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
