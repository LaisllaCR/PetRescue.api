using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetController : BaseController
    {
        // GET: api/Pet
        [HttpGet]
        public IEnumerable<PetDto> GetPet()
        {
            try
            {
                return UnitOfWork.Pet.GetPets();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET: api/Pet/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPet([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var pet = UnitOfWork.Pet.GetPetByID(id);

                if (pet == null)
                {
                    return NotFound();
                }

                return Ok(pet);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Pet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet([FromRoute] int id, [FromBody] PetDto pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.PetId)
            {
                return BadRequest();
            }

            try
            {
                UnitOfWork.Pet.UpdatePet(pet);
                UnitOfWork.Pet.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // POST: api/Pet
        [HttpPost]
        public async Task<IActionResult> PostPet([FromBody] PetDto pet)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Pet.InsertPet(pet);
                UnitOfWork.Pet.Save();

                return CreatedAtAction("GetPet", new { id = pet.PetId }, pet);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE: api/Pet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var pet = UnitOfWork.Pet.GetPetByID(id);
                if (pet == null)
                {
                    return NotFound();
                }

                UnitOfWork.Pet.DeletePet(id);
                UnitOfWork.Pet.Save();

                return Ok(pet);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool PetExists(int id)
        {
            try
            {
                return UnitOfWork.Pet.PetExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}