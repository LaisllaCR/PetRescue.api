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
        public IEnumerable<Breed> GetBreed()
        {
            return UnityOfWork.Breed.GetBreeds();
        }

        // GET: api/Breed/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var breed = UnityOfWork.Breed.GetBreedByID(id);

            if (breed == null)
            {
                return NotFound();
            }

            return Ok(breed);
        }

        // PUT: api/Breed/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreed([FromRoute] int id, [FromBody] Breed breed)
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
                UnityOfWork.Breed.UpdateBreed(breed);
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
        public async Task<IActionResult> PostBreed([FromBody] Breed breed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UnityOfWork.Breed.InsertBreed(breed);

            return CreatedAtAction("GetBreed", new { id = breed.BreedId }, breed);
        }

        // DELETE: api/Breed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var breed = UnityOfWork.Breed.GetBreedByID(id);

            if (breed == null)
            {
                return NotFound();
            }

            UnityOfWork.Breed.DeleteBreed(id);

            return Ok(breed);
        }

        private bool BreedExists(int id)
        {
            return UnityOfWork.Breed.BreedExists(id);
        }
    }
}