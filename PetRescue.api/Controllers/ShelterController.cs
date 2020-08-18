using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShelterController : ControllerBase
    {
        private readonly IShelterRepository _shelterRepository;

        public ShelterController(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository ?? throw new ArgumentNullException(nameof(shelterRepository));
        }

        // GET: api/Shelter
        [HttpGet]
        public IEnumerable<ShelterDto> GetShelter()
        {
            try
            {
                return _shelterRepository.GetShelters();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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

                var shelter = _shelterRepository.GetShelterByID(id);

                if (shelter == null)
                {
                    return NotFound();
                }

                return Ok(shelter);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                _shelterRepository.UpdateShelter(shelter);
                _shelterRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ShelterExists(id))
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

                _shelterRepository.InsertShelter(shelter);
                _shelterRepository.Save();

                return CreatedAtAction("GetShelter", new { id = shelter.ShelterId }, shelter);
            }
            catch (Exception ex)
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

                var shelter = _shelterRepository.GetShelterByID(id);

                if (shelter == null)
                {
                    return NotFound();
                }

                _shelterRepository.DeleteShelter(id);
                _shelterRepository.Save();

                return Ok(shelter);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool ShelterExists(int id)
        {
            try
            {
                return _shelterRepository.ShelterExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}