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
    public class SocialMidiaRepository : ISocialMidiaRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public SocialMidiaRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteSocialMidia(int id)
        {
            try
            {
                SocialMidia socialMidia = _context.SocialMidia.Find(id);
                _context.SocialMidia.Remove(socialMidia);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public SocialMidiaDto GetSocialMidiaByID(int id)
        {
            try
            {
                SocialMidia socialMidia = _context.SocialMidia.Find(id);
                return _mapper.Map<SocialMidiaDto>(socialMidia);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SocialMidiaDto> GetSocialMidias()
        {
            try
            {
                List<SocialMidia> allSocialMidias = _context.SocialMidia.OrderBy(x => x.Description).ToList();

                List<SocialMidiaDto> allSocialMidiasDtos = _mapper.Map<List<SocialMidia>, List<SocialMidiaDto>>(allSocialMidias);

                return allSocialMidiasDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertSocialMidia(SocialMidiaDto resource)
        {
            try
            {
                SocialMidia socialMidia = new SocialMidia();
                socialMidia.SocialMidiaId = resource.SocialMidiaId;
                socialMidia.Description = resource.Description;
                _context.SocialMidia.Add(socialMidia);
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

        public bool SocialMidiaExists(int id)
        {
            try
            {
                return _context.SocialMidia.Any(e => e.SocialMidiaId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateSocialMidia(SocialMidiaDto resource)
        {
            try
            {
                SocialMidia socialMidia = _context.SocialMidia.Find(resource.SocialMidiaId);

                _context.Entry(socialMidia).State = EntityState.Modified;

                socialMidia.Description = resource.Description;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
