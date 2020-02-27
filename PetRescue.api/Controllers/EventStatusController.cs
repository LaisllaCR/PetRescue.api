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
    public class EventStatusController : BaseController
    {
        // GET: api/EventStatus
        [HttpGet]
        public IEnumerable<EventStatusResource> GetEventStatus()
        {
            try
            {
                return UnityOfWork.EventStatus.GetEventStatuss();

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

                var eventStatus = UnityOfWork.EventStatus.GetEventStatusByID(id);

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
        public async Task<IActionResult> PutEventStatus([FromRoute] int id, [FromBody] EventStatusResource eventStatus)
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
                UnityOfWork.EventStatus.UpdateEventStatus(eventStatus);
                UnityOfWork.EventStatus.Save();
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
        public async Task<IActionResult> PostEventStatus([FromBody] EventStatusResource eventStatus)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnityOfWork.EventStatus.InsertEventStatus(eventStatus);
                UnityOfWork.EventStatus.Save();

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

                var eventStatus = UnityOfWork.EventStatus.GetEventStatusByID(id);
                if (eventStatus == null)
                {
                    return NotFound();
                }

                UnityOfWork.EventStatus.DeleteEventStatus(id);
                UnityOfWork.EventStatus.Save();

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
                return UnityOfWork.EventStatus.EventStatusExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}