﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EventTypeController : BaseController
    {
        // GET: api/EventType
        [HttpGet]
        public IEnumerable<EventTypeResource> GetEventType()
        {
            try
            {
                return UnityOfWork.EventType.GetEventTypes();

            }
            catch (System.Exception)
            {

                throw;
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

                var eventType = UnityOfWork.EventType.GetEventTypeByID(id);

                if (eventType == null)
                {
                    return NotFound();
                }

                return Ok(eventType);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/EventType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventType([FromRoute] int id, [FromBody] EventTypeResource eventType)
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
                UnityOfWork.EventType.UpdateEventType(eventType);
                UnityOfWork.EventType.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTypeExists(id))
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

        // POST: api/EventType
        [HttpPost]
        public async Task<IActionResult> PostEventType([FromBody] EventTypeResource eventType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnityOfWork.EventType.InsertEventType(eventType);
                UnityOfWork.EventType.Save();

                return CreatedAtAction("GetEventType", new { id = eventType.EventTypeId }, eventType);
            }
            catch (System.Exception)
            {

                throw;
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

                var eventType = UnityOfWork.EventType.GetEventTypeByID(id);
                if (eventType == null)
                {
                    return NotFound();
                }

                UnityOfWork.EventType.DeleteEventType(id);
                UnityOfWork.EventType.Save();

                return Ok(eventType);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool EventTypeExists(int id)
        {
            try
            {
                return UnityOfWork.EventType.EventTypeExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}