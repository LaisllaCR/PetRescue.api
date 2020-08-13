using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class EventStatusRepository : IEventStatusRepository
    {
        private readonly dbContext _context;

        public EventStatusRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteEventStatus(int id)
        {
            try
            {
                EventStatus eventStatus = _context.EventStatus.Find(id);
                _context.EventStatus.Remove(eventStatus);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public EventStatusDto GetEventStatusByID(int id)
        {
            try
            {
                return new EventStatusDto(_context.EventStatus.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<EventStatusDto> GetEventStatuss()
        {
            try
            {
                return (from eventStatus in _context.EventStatus select new EventStatusDto(eventStatus)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertEventStatus(EventStatusDto resource)
        {
            try
            {
                EventStatus eventStatus = new EventStatus();
                eventStatus.EventStatusTypeId = resource.EventStatusTypeId;
                eventStatus.Description = resource.Description;
                _context.EventStatus.Add(eventStatus);
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

        public bool EventStatusExists(int id)
        {
            try
            {
                return _context.EventStatus.Any(e => e.EventStatusTypeId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateEventStatus(EventStatusDto resource)
        {
            try
            {
                EventStatus eventStatus = _context.EventStatus.Find(resource.EventStatusTypeId);

                _context.Entry(eventStatus).State = EntityState.Modified;

                eventStatus.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
