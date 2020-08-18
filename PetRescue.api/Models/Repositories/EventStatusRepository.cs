using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue.api.Models.Repositories
{
    public class EventStatusRepository : IEventStatusRepository
    {
        private readonly dbContext _context;
        private readonly IMapper _mapper;

        public EventStatusRepository(dbContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteEventStatus(int id)
        {
            try
            {
                EventStatus eventStatus = _context.EventStatus.Find(id);
                _context.EventStatus.Remove(eventStatus);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public EventStatusDto GetEventStatusByID(int id)
        {
            try
            {
                EventStatus eventStatus = _context.EventStatus.Find(id);
                return _mapper.Map<EventStatusDto>(eventStatus);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<EventStatusDto> GetEventStatuss()
        {
            try
            {
                List<EventStatus> allEventStatuss = _context.EventStatus.OrderBy(x => x.Description).ToList();

                List<EventStatusDto> allEventStatussDtos = _mapper.Map<List<EventStatus>, List<EventStatusDto>>(allEventStatuss);

                return allEventStatussDtos;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void InsertEventStatus(EventStatusDto resource)
        {
            try
            {
                EventStatus eventStatus = new EventStatus();
                eventStatus.Description = resource.Description;
                _context.EventStatus.Add(eventStatus);
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

        public bool EventStatusExists(int id)
        {
            try
            {
                return _context.EventStatus.Any(e => e.EventStatusId == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
