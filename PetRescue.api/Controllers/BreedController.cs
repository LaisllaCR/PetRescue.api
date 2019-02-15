using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly dbContext _context;

        public BreedController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Breed
        [HttpGet]
        public IEnumerable<Breed> GetBreed()
        {
            return _context.Breed;
        }

        // GET: api/Breed/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var breed = await _context.Breed.FindAsync(id);

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

            if (id != breed.ID)
            {
                return BadRequest();
            }

            _context.Entry(breed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            _context.Breed.Add(breed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreed", new { id = breed.ID }, breed);
        }

        // DELETE: api/Breed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var breed = await _context.Breed.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }

            _context.Breed.Remove(breed);
            await _context.SaveChangesAsync();

            return Ok(breed);
        }

        private bool BreedExists(int id)
        {
            return _context.Breed.Any(e => e.ID == id);
        }
    }
}