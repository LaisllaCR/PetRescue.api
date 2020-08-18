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
    public class PetRepository :  IPetRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public PetRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeletePet(int id)
        {
            try
            {
                Pet pet = _context.Pet.Find(id);
                _context.Pet.Remove(pet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PetDto GetPetByID(int id)
        {
            try
            {
                Pet pet = _context.Pet.Find(id);
                return _mapper.Map<PetDto>(pet);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PetDto> GetPets()
        {
            try
            {
                List<Pet> allPets = _context.Pet.OrderBy(x => x.PetId).ToList();

                List<PetDto> allPetsDtos = _mapper.Map<List<Pet>, List<PetDto>>(allPets);

                return allPetsDtos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertPet(PetDto resource)
        {
            try
            {
                if (_context.Pet.Find(resource.PetId) == null)
                {
                    throw new Exception("Pet not found");
                }
                if (_context.Breed.Find(resource.BreedId) == null)
                {
                    throw new Exception("Breed not found");
                }
                if (_context.Size.Find(resource.SizeId) == null)
                {
                    throw new Exception("Size not found");
                }
                if (_context.Age.Find(resource.AgeId) == null)
                {
                    throw new Exception("Age not found");
                }
                if (_context.Pelage.Find(resource.HairId) == null)
                {
                    throw new Exception("Hair not found");
                }

                Pet pet = _mapper.Map<Pet>(resource);

                _context.Pet.Add(pet);
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

        public bool PetExists(int id)
        {
            try
            {
                return _context.Pet.Any(e => e.PetId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePet(PetDto resource)
        {
            try
            {
                Pet pet = _context.Pet.Find(resource.PetId);

                _context.Entry(pet).State = EntityState.Modified;

                if (_context.Pet.Find(resource.PetId) == null)
                {
                    throw new Exception("Pet not found");
                }
                if (_context.Breed.Find(resource.BreedId) == null)
                {
                    throw new Exception("Breed not found");
                }
                if (_context.Size.Find(resource.SizeId) == null)
                {
                    throw new Exception("Size not found");
                }
                if (_context.Age.Find(resource.AgeId) == null)
                {
                    throw new Exception("Age not found");
                }
                if (_context.Pelage.Find(resource.HairId) == null)
                {
                    throw new Exception("Hair not found");
                }

                pet = _mapper.Map<Pet>(resource);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
