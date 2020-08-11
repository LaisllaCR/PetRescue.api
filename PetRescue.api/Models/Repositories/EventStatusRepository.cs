using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Repositories
{
    public class EventStatusRepository : Repository<EventStatus>, IEventStatusRepository
    {
        public EventStatusRepository(dbContext context) : base(context) { }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public void DeleteEventStatus(int id)
        {
            try
            {
                EventStatus eventStatus = dbContext.EventStatus.Find(id);
                dbContext.EventStatus.Remove(eventStatus);
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
                return new EventStatusDto(dbContext.EventStatus.Find(id));

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
                return (from eventStatus in dbContext.EventStatus select new EventStatusDto(eventStatus)).ToList();

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
                dbContext.EventStatus.Add(eventStatus);
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

        public bool EventStatusExists(int id)
        {
            try
            {
                return dbContext.EventStatus.Any(e => e.EventStatusTypeId == id);

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
                EventStatus eventStatus = dbContext.EventStatus.Find(resource.EventStatusTypeId);

                dbContext.Entry(eventStatus).State = EntityState.Modified;

                eventStatus.Description = resource.Description;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
