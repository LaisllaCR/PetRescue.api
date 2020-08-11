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
    [Authorize]
    public class ShelterController : BaseController
    {
        // GET: api/Shelter
        [HttpGet]
        public IEnumerable<ShelterDto> GetShelter()
        {
            try
            {
                return UnitOfWork.Shelter.GetShelters();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET: api/Shelter/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShelter([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var shelter = UnitOfWork.Shelter.GetShelterByID(id);

                if (shelter == null)
                {
                    return NotFound();
                }

                return Ok(shelter);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Shelter/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelter([FromRoute] int id, [FromBody] ShelterDto shelter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shelter.ShelterId)
            {
                return BadRequest();
            }

            try
            {
                UnitOfWork.Shelter.UpdateShelter(shelter);
                UnitOfWork.Shelter.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShelterExists(id))
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

        // POST: api/Shelter
        [HttpPost]
        public async Task<IActionResult> PostShelter([FromBody] ShelterDto shelter)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Shelter.InsertShelter(shelter);
                UnitOfWork.Shelter.Save();

                return CreatedAtAction("GetShelter", new { id = shelter.ShelterId }, shelter);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Shelter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShelter([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var shelter = UnitOfWork.Shelter.GetShelterByID(id);

                if (shelter == null)
                {
                    return NotFound();
                }

                UnitOfWork.Shelter.DeleteShelter(id);
                UnitOfWork.Shelter.Save();

                return Ok(shelter);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool ShelterExists(int id)
        {
            try
            {
                return UnitOfWork.Shelter.ShelterExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}