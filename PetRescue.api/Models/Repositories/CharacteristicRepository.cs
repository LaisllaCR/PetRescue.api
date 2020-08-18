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
    public class CharacteristicRepository : ICharacteristicRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public CharacteristicRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CharacteristicRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteCharacteristic(int id)
        {
            try
            {
                Characteristic characteristic = _context.Characteristic.Find(id);
                _context.Characteristic.Remove(characteristic);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public CharacteristicDto GetCharacteristicByID(int id)
        {
            try
            {
                Characteristic characteristic = _context.Characteristic.Find(id);
                return _mapper.Map<CharacteristicDto>(characteristic);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CharacteristicDto> GetCharacteristics()
        {
            try
            {
                List<Characteristic> allCharacteristics = _context.Characteristic.OrderBy(x => x.Description).ToList();

                List<CharacteristicDto> allCharacteristicsDtos = _mapper.Map<List<Characteristic>, List<CharacteristicDto>>(allCharacteristics);

                return allCharacteristicsDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertCharacteristic(CharacteristicDto resource)
        {
            try
            {
                Characteristic characteristic = new Characteristic();
                characteristic.CharacteristicId = resource.CharacteristicId;
                characteristic.Description = resource.Description;
                _context.Characteristic.Add(characteristic);
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

        public bool CharacteristicExists(int id)
        {
            try
            {
                return _context.Characteristic.Any(e => e.CharacteristicId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateCharacteristic(CharacteristicDto resource)
        {
            try
            {
                Characteristic characteristic = _context.Characteristic.Find(resource.CharacteristicId);

                _context.Entry(characteristic).State = EntityState.Modified;

                characteristic.Description = resource.Description;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
