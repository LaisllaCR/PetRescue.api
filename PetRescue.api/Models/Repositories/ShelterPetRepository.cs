using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class ShelterPetRepository : IShelterPetRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public ShelterPetRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteShelterPet(int id)
        {
            try
            {
                ShelterPet shelterPet = _context.ShelterPet.Find(id);
                _context.ShelterPet.Remove(shelterPet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ShelterPetDto GetShelterPetByID(int id)
        {
            try
            {
                ShelterPet shelterPet = _context.ShelterPet.Find(id);
                return _mapper.Map<ShelterPetDto>(shelterPet);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ShelterPetDto> GetShelterPets()
        {
            try
            {
                List<ShelterPet> allShelterPets = _context.ShelterPet.OrderBy(x => x.ShelterPetId).ToList();

                List<ShelterPetDto> allShelterPetsDtos = _mapper.Map<List<ShelterPet>, List<ShelterPetDto>>(allShelterPets);

                return allShelterPetsDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertShelterPet(ShelterPetDto resource)
        {
            try
            {
                ShelterPet shelterPet = new ShelterPet();
                shelterPet.ShelterPetId = resource.ShelterPetId;
                _context.ShelterPet.Add(shelterPet);
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

        public bool ShelterPetExists(int id)
        {
            try
            {
                return _context.ShelterPet.Any(e => e.ShelterPetId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateShelterPet(ShelterPetDto resource)
        {
            try
            {
                ShelterPet shelterPet = _context.ShelterPet.Find(resource.ShelterPetId);

                _context.Entry(shelterPet).State = EntityState.Modified;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
