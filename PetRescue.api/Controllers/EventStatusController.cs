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
    public class EventStatusController : ControllerBase
    {
        private readonly IEventStatusRepository _eventStatusRepository;

        public EventStatusController(IEventStatusRepository eventStatusRepository)
        {
            _eventStatusRepository = eventStatusRepository ?? throw new ArgumentNullException(nameof(eventStatusRepository));
        }

        // GET: api/EventStatus
        [HttpGet]
        public IEnumerable<EventStatusDto> GetEventStatus()
        {
            try
            {
                return _eventStatusRepository.GetEventStatuss();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET: api/EventStatus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventStatus([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var eventStatus = _eventStatusRepository.GetEventStatusByID(id);

                if (eventStatus == null)
                {
                    return NotFound();
                }

                return Ok(eventStatus);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/EventStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventStatus([FromRoute] int id, [FromBody] EventStatusDto eventStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventStatus.EventStatusTypeId)
            {
                return BadRequest();
            }

            try
            {
                _eventStatusRepository.UpdateEventStatus(eventStatus);
                _eventStatusRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventStatus
        [HttpPost]
        public async Task<IActionResult> PostEventStatus([FromBody] EventStatusDto eventStatus)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _eventStatusRepository.InsertEventStatus(eventStatus);
                _eventStatusRepository.Save();

                return CreatedAtAction("GetEventStatus", new { id = eventStatus.EventStatusTypeId }, eventStatus);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE: api/EventStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventStatus([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var eventStatus = _eventStatusRepository.GetEventStatusByID(id);
                if (eventStatus == null)
                {
                    return NotFound();
                }

                _eventStatusRepository.DeleteEventStatus(id);
                _eventStatusRepository.Save();

                return Ok(eventStatus);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool EventStatusExists(int id)
        {
            try
            {
                return _eventStatusRepository.EventStatusExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}