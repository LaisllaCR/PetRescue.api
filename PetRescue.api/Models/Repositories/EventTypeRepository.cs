using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly dbContext _context;

        public EventTypeRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteEventType(int id)
        {
            try
            {
                EventType eventType = _context.EventType.Find(id);
                _context.EventType.Remove(eventType);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public EventTypeDto GetEventTypeByID(int id)
        {
            try
            {
                return new EventTypeDto(_context.EventType.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<EventTypeDto> GetEventTypes()
        {
            try
            {
                return (from eventType in _context.EventType select new EventTypeDto(eventType)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertEventType(EventTypeDto resource)
        {
            try
            {
                EventType eventType = new EventType();
                eventType.EventTypeId = resource.EventTypeId;
                eventType.Description = resource.Description;
                _context.EventType.Add(eventType);
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

        public bool EventTypeExists(int id)
        {
            try
            {
                return _context.EventType.Any(e => e.EventTypeId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateEventType(EventTypeDto resource)
        {
            try
            {
                EventType eventType = _context.EventType.Find(resource.EventTypeId);

                _context.Entry(eventType).State = EntityState.Modified;

                eventType.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
