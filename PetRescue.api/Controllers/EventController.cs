﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    [Route("v1/events")]
    [ApiController]
    [AllowAnonymous]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<EventDto> GetEvent()
        {
            try
            {
                return _eventRepository.GetEvents();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var eventDto = _eventRepository.GetEventByID(id);

                if (eventDto == null)
                {
                    return NotFound();
                }

                return Ok(eventDto);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] EventDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventDto.EventId)
            {
                return BadRequest();
            }

            try
            {
                _eventRepository.UpdateEvent(eventDto);
                _eventRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EventExists(id))
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

        // POST: api/Event
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] EventDto eventDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _eventRepository.InsertEvent(eventDto);
                _eventRepository.Save();

                return CreatedAtAction("GetEvent", new { id = eventDto.EventId }, eventDto);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var eventDto = _eventRepository.GetEventByID(id);
                if (eventDto == null)
                {
                    return NotFound();
                }

                _eventRepository.DeleteEvent(id);
                _eventRepository.Save();

                return Ok(eventDto);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool EventExists(int id)
        {
            try
            {
                return _eventRepository.EventExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}