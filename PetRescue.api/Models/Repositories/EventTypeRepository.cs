using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Models.Repositories
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public EventTypeRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteEventType(int id)
        {
            try
            {
                EventType eventType = _context.EventType.Find(id);
                _context.EventType.Remove(eventType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public EventTypeDto GetEventTypeByID(int id)
        {
            try
            {
                EventType eventType = _context.EventType.Find(id);
                return _mapper.Map<EventTypeDto>(eventType);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<EventTypeDto> GetEventTypes()
        {
            try
            {
                List<EventType> allEventTypes = _context.EventType.OrderBy(x => x.Description).ToList();

                List<EventTypeDto> allEventTypesDtos = _mapper.Map<List<EventType>, List<EventTypeDto>>(allEventTypes);

                return allEventTypesDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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

        public bool EventTypeExists(int id)
        {
            try
            {
                return _context.EventType.Any(e => e.EventTypeId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
