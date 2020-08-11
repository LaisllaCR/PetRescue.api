using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class EventTypeRepository : Repository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteEventType(int id)
        {
            try
            {
                EventType eventType = dbContext.EventType.Find(id);
                dbContext.EventType.Remove(eventType);
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
                return new EventTypeDto(dbContext.EventType.Find(id));

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
                return (from eventType in dbContext.EventType select new EventTypeDto(eventType)).ToList();

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
                dbContext.EventType.Add(eventType);
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
                dbContext.SaveChanges();

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
                return dbContext.EventType.Any(e => e.EventTypeId == id);

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
                EventType eventType = dbContext.EventType.Find(resource.EventTypeId);

                dbContext.Entry(eventType).State = EntityState.Modified;

                eventType.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
