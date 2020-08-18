using AutoMapper;
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
        private readonly IMapper _mapper;

        public EventRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteEvent(int id)
        {
            try
            {
                Event eventEntity = _context.Event.Find(id);
                _context.Event.Remove(eventEntity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public EventDto GetEventByID(int id)
        {
            try
            {
                Event eventDb = _context.Event.Find(id);
                return _mapper.Map<EventDto>(eventDb);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<EventDto> GetEvents()
        {
            try
            {
                List<Event> allEvents = _context.Event.OrderBy(x => x.Description).ToList();

                List<EventDto> allEventsDtos = _mapper.Map<List<Event>, List<EventDto>>(allEvents);

                return allEventsDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertEvent(EventDto resource)
        {
            try
            {
                Event eventEntity = new Event();
                eventEntity.PetId = resource.EventId;
                eventEntity.Date = resource.When;
                eventEntity.Description = resource.What;
                eventEntity.Location = resource.Where;
                eventEntity.Reward = resource.Reward;
                eventEntity.CreationDate = resource.CreationDate;
                eventEntity.EventTypeId = resource.EventTypeId;
                eventEntity.LocationTypeId = resource.LocationTypeId;
                eventEntity.EventStatusId = resource.EventStatusId;

                _context.Event.Add(eventEntity);
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

        public bool EventExists(int id)
        {
            try
            {
                return _context.Event.Any(e => e.EventId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateEvent(EventDto resource)
        {
            try
            {
                Event eventEntity = _context.Event.Find(resource.EventId);

                _context.Entry(eventEntity).State = EntityState.Modified;

                eventEntity.PetId = resource.EventId;
                eventEntity.Date = resource.When;
                eventEntity.Description = resource.What;
                eventEntity.Location = resource.Where;
                eventEntity.Reward = resource.Reward;
                eventEntity.CreationDate = resource.CreationDate;
                eventEntity.EventTypeId = resource.EventTypeId;
                eventEntity.LocationTypeId = resource.LocationTypeId;
                eventEntity.EventStatusId = resource.EventStatusId;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
