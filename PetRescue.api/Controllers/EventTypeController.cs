using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeRepository _eventTypeRepository;

        public EventTypeController(IEventTypeRepository eventTypeRepository)
        {
            _eventTypeRepository = eventTypeRepository ?? throw new ArgumentNullException(nameof(eventTypeRepository));
        }

        // GET: api/EventType
        [HttpGet]
        public IEnumerable<EventTypeDto> GetEventType()
        {
            try
            {
                return _eventTypeRepository.GetEventTypes();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: api/EventType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventType([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var eventType = _eventTypeRepository.GetEventTypeByID(id);

                if (eventType == null)
                {
                    return NotFound();
                }

                return Ok(eventType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/EventType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventType([FromRoute] int id, [FromBody] EventTypeDto eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventType.EventTypeId)
            {
                return BadRequest();
            }

            try
            {
                _eventTypeRepository.UpdateEventType(eventType);
                _eventTypeRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EventTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return NoContent();
        }

        // POST: api/EventType
        [HttpPost]
        public async Task<IActionResult> PostEventType([FromBody] EventTypeDto eventType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _eventTypeRepository.InsertEventType(eventType);
                _eventTypeRepository.Save();

                return CreatedAtAction("GetEventType", new { id = eventType.EventTypeId }, eventType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/EventType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventType([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var eventType = _eventTypeRepository.GetEventTypeByID(id);
                if (eventType == null)
                {
                    return NotFound();
                }

                _eventTypeRepository.DeleteEventType(id);
                _eventTypeRepository.Save();

                return Ok(eventType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool EventTypeExists(int id)
        {
            try
            {
                return _eventTypeRepository.EventTypeExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}