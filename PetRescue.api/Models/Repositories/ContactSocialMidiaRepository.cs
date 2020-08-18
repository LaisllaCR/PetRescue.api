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
    public class ContactSocialMidiaRepository : IContactSocialMidiaRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public ContactSocialMidiaRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteContactSocialMidia(int id)
        {
            try
            {
                ContactSocialMidia contactSocialMidia = _context.ContactSocialMidia.Find(id);
                _context.ContactSocialMidia.Remove(contactSocialMidia);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ContactSocialMidiaDto GetContactSocialMidiaByID(int id)
        {
            try
            {
                ContactSocialMidia contactSocialMidia = _context.ContactSocialMidia.Find(id);
                return _mapper.Map<ContactSocialMidiaDto>(contactSocialMidia);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ContactSocialMidiaDto> GetContactSocialMidias()
        {
            try
            {
                List<ContactSocialMidia> allContactSocialMidias = _context.ContactSocialMidia.OrderBy(x => x.ContactSocialMidiaId).ToList();

                List<ContactSocialMidiaDto> allContactSocialMidiasDtos = _mapper.Map<List<ContactSocialMidia>, List<ContactSocialMidiaDto>>(allContactSocialMidias);

                return allContactSocialMidiasDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertContactSocialMidia(ContactSocialMidiaDto resource)
        {
            try
            {
                ContactSocialMidia contactSocialMidia = new ContactSocialMidia();
                contactSocialMidia.SocialMidiaId = resource.SocialMidiaId;
                contactSocialMidia.ContactId = resource.ContactId;

                _context.ContactSocialMidia.Add(contactSocialMidia);
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

        public bool ContactSocialMidiaExists(int id)
        {
            try
            {
                return _context.ContactSocialMidia.Any(e => e.ContactSocialMidiaId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateContactSocialMidia(ContactSocialMidiaDto resource)
        {
            try
            {
                ContactSocialMidia contactSocialMidia = _context.ContactSocialMidia.Find(resource.ContactSocialMidiaId);

                _context.Entry(contactSocialMidia).State = EntityState.Modified;

                contactSocialMidia.SocialMidiaId = resource.SocialMidiaId;
                contactSocialMidia.ContactId = resource.ContactId;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
