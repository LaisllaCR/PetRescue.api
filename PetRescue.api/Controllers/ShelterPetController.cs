using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Repositories;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShelterPetController : ControllerBase
    {
        private readonly IShelterPetRepository _shelterPetRepository;

        public ShelterPetController(IShelterPetRepository shelterPetRepository)
        {
            _shelterPetRepository = shelterPetRepository ?? throw new ArgumentNullException(nameof(shelterPetRepository));
        }

        // GET: api/ShelterPet
        [HttpGet]
        public IEnumerable<ShelterPetDto> GetShelterPet()
        {
            try
            {
                return _shelterPetRepository.GetShelterPets();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: api/ShelterPet/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShelterPet([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var shelterPet = _shelterPetRepository.GetShelterPetByID(id);

                if (shelterPet == null)
                {
                    return NotFound();
                }

                return Ok(shelterPet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/ShelterPet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelterPet([FromRoute] int id, [FromBody] ShelterPetDto shelterPet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shelterPet.ShelterPetId)
            {
                return BadRequest();
            }

            try
            {
                _shelterPetRepository.UpdateShelterPet(shelterPet);
                _shelterPetRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ShelterPetExists(id))
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

        // POST: api/ShelterPet
        [HttpPost]
        public async Task<IActionResult> PostShelterPet([FromBody] ShelterPetDto shelterPet)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _shelterPetRepository.InsertShelterPet(shelterPet);
                _shelterPetRepository.Save();

                return CreatedAtAction("GetShelterPet", new { id = shelterPet.ShelterPetId }, shelterPet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/ShelterPet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShelterPet([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var shelterPet = _shelterPetRepository.GetShelterPetByID(id);
                if (shelterPet == null)
                {
                    return NotFound();
                }

                _shelterPetRepository.DeleteShelterPet(id);
                _shelterPetRepository.Save();

                return Ok(shelterPet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool ShelterPetExists(int id)
        {
            try
            {
                return _shelterPetRepository.ShelterPetExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}