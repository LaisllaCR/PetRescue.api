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

        public SocialMidiaRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteSocialMidia(int id)
        {
            try
            {
                SocialMidia socialMidia = _context.SocialMidia.Find(id);
                _context.SocialMidia.Remove(socialMidia);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public SocialMidiaDto GetSocialMidiaByID(int id)
        {
            try
            {
                return new SocialMidiaDto(_context.SocialMidia.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<SocialMidiaDto> GetSocialMidias()
        {
            try
            {
                return (from socialMidia in _context.SocialMidia select new SocialMidiaDto(socialMidia)).ToList();

            }
            catch (System.Exception)
            {

                throw;
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
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool SocialMidiaExists(int id)
        {
            try
            {
                return _context.SocialMidia.Any(e => e.SocialMidiaId == id);

            }
            catch (System.Exception)
            {

                throw;
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
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
