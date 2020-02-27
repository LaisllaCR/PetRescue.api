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
    public class ShelterPetController : BaseController
    {
        // GET: api/ShelterPet
        [HttpGet]
        public IEnumerable<ShelterPetResource> GetShelterPet()
        {
            try
            {
                return UnitOfWork.ShelterPet.GetShelterPets();

            }
            catch (System.Exception)
            {

                throw;
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

                var shelterPet = UnitOfWork.ShelterPet.GetShelterPetByID(id);

                if (shelterPet == null)
                {
                    return NotFound();
                }

                return Ok(shelterPet);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/ShelterPet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelterPet([FromRoute] int id, [FromBody] ShelterPetResource shelterPet)
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
                UnitOfWork.ShelterPet.UpdateShelterPet(shelterPet);
                UnitOfWork.ShelterPet.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShelterPetExists(id))
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

        // POST: api/ShelterPet
        [HttpPost]
        public async Task<IActionResult> PostShelterPet([FromBody] ShelterPetResource shelterPet)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.ShelterPet.InsertShelterPet(shelterPet);
                UnitOfWork.ShelterPet.Save();

                return CreatedAtAction("GetShelterPet", new { id = shelterPet.ShelterPetId }, shelterPet);
            }
            catch (System.Exception)
            {

                throw;
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

                var shelterPet = UnitOfWork.ShelterPet.GetShelterPetByID(id);
                if (shelterPet == null)
                {
                    return NotFound();
                }

                UnitOfWork.ShelterPet.DeleteShelterPet(id);
                UnitOfWork.ShelterPet.Save();

                return Ok(shelterPet);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool ShelterPetExists(int id)
        {
            try
            {
                return UnitOfWork.ShelterPet.ShelterPetExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}