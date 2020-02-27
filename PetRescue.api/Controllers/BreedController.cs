using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BreedController : BaseController
    {
        // GET: api/Breed
        [HttpGet]
        public IEnumerable<BreedResource> GetBreed()
        {
            try
            {
                return UnitOfWork.Breed.GetBreeds();

            }
            catch (System.Exception)
            {

                throw;
            }    
        }

        // GET: api/Breed/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreed([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var breed = UnitOfWork.Breed.GetBreedByID(id);

                if (breed == null)
                {
                    return NotFound();
                }

                return Ok(breed);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Breed/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreed([FromRoute] int id, [FromBody] BreedResource breed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != breed.BreedId)
            {
                return BadRequest();
            }
            
            try
            {
                UnitOfWork.Breed.UpdateBreed(breed);
                UnitOfWork.Breed.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(id))
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

        // POST: api/Breed
        [HttpPost]
        public async Task<IActionResult> PostBreed([FromBody] BreedResource breed)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Breed.InsertBreed(breed);
                UnitOfWork.Breed.Save();

                return CreatedAtAction("GetBreed", new { id = breed.BreedId }, breed);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Breed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var breed = UnitOfWork.Breed.GetBreedByID(id);

                if (breed == null)
                {
                    return NotFound();
                }

                UnitOfWork.Breed.DeleteBreed(id);
                UnitOfWork.Breed.Save();

                return Ok(breed);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool BreedExists(int id)
        {
            try
            {
                return UnitOfWork.Breed.BreedExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }       
        }
    }
}