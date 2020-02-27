using System;
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
    public class EventController : BaseController
    {
        // GET: api/Event
        [HttpGet]
        public IEnumerable<EventResource> GetEvent()
        {
            try
            {
                return UnitOfWork.Event.GetEvents();

            }
            catch (System.Exception)
            {

                throw;
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

                var eventResource = UnitOfWork.Event.GetEventByID(id);

                if (eventResource == null)
                {
                    return NotFound();
                }

                return Ok(eventResource);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] EventResource eventResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventResource.EventId)
            {
                return BadRequest();
            }

            try
            {
                UnitOfWork.Event.UpdateEvent(eventResource);
                UnitOfWork.Event.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Event
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] EventResource eventResource)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Event.InsertEvent(eventResource);
                UnitOfWork.Event.Save();

                return CreatedAtAction("GetEvent", new { id = eventResource.EventId }, eventResource);
            }
            catch (System.Exception)
            {

                throw;
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

                var eventResource = UnitOfWork.Event.GetEventByID(id);
                if (eventResource == null)
                {
                    return NotFound();
                }

                UnitOfWork.Event.DeleteEvent(id);
                UnitOfWork.Event.Save();

                return Ok(eventResource);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool EventExists(int id)
        {
            try
            {
                return UnitOfWork.Event.EventExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}