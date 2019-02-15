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
    public class AgeController : ControllerBase
    {
        private readonly dbContext _context;

        public AgeController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Age
        [HttpGet]
        public IEnumerable<Age> GetAge()
        {
            return _context.Age;
        }

        // GET: api/Age/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var age = await _context.Age.FindAsync(id);

            if (age == null)
            {
                return NotFound();
            }

            return Ok(age);
        }

        // PUT: api/Age/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAge([FromRoute] int id, [FromBody] Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != age.ID)
            {
                return BadRequest();
            }

            _context.Entry(age).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeExists(id))
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

        // POST: api/Age
        [HttpPost]
        public async Task<IActionResult> PostAge([FromBody] Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Age.Add(age);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAge", new { id = age.ID }, age);
        }

        // DELETE: api/Age/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var age = await _context.Age.FindAsync(id);
            if (age == null)
            {
                return NotFound();
            }

            _context.Age.Remove(age);
            await _context.SaveChangesAsync();

            return Ok(age);
        }

        private bool AgeExists(int id)
        {
            return _context.Age.Any(e => e.ID == id);
        }
    }
}