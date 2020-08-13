using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly dbContext _context;

        public EventRepository(dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteEvent(int id)
        {
            try
            {
                Event eventEntity = _context.Event.Find(id);
                _context.Event.Remove(eventEntity);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public EventDto GetEventByID(int id)
        {
            try
            {
                return new EventDto(_context.Event.Find(id));

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<EventDto> GetEvents()
        {
            try
            {
                return (from eventEntity in _context.Event select new EventDto(eventEntity)).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void InsertEvent(EventDto resource)
        {
            try
            {
                Event eventEntity = new Event();
                eventEntity.PetId = resource.EventId;
                eventEntity.When = resource.When;
                eventEntity.What = resource.What;
                eventEntity.Where = resource.Where;
                eventEntity.Reward = resource.Reward;
                eventEntity.CreationDate = resource.CreationDate;
                eventEntity.EventTypeId = resource.EventTypeId;
                eventEntity.LocationTypeId = resource.LocationTypeId;
                eventEntity.EventStatusId = resource.EventStatusId;

                _context.Event.Add(eventEntity);
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

        public bool EventExists(int id)
        {
            try
            {
                return _context.Event.Any(e => e.EventId == id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateEvent(EventDto resource)
        {
            try
            {
                Event eventEntity = _context.Event.Find(resource.EventId);

                _context.Entry(eventEntity).State = EntityState.Modified;

                eventEntity.PetId = resource.EventId;
                eventEntity.When = resource.When;
                eventEntity.What = resource.What;
                eventEntity.Where = resource.Where;
                eventEntity.Reward = resource.Reward;
                eventEntity.CreationDate = resource.CreationDate;
                eventEntity.EventTypeId = resource.EventTypeId;
                eventEntity.LocationTypeId = resource.LocationTypeId;
                eventEntity.EventStatusId = resource.EventStatusId;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
