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
    public class HairController : ControllerBase
    {
        private readonly dbContext _context;

        public HairController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Hair
        [HttpGet]
        public IEnumerable<Hair> GetHair()
        {
            return _context.Hair;
        }

        // GET: api/Hair/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHair([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hair = await _context.Hair.FindAsync(id);

            if (hair == null)
            {
                return NotFound();
            }

            return Ok(hair);
        }

        // PUT: api/Hair/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHair([FromRoute] int id, [FromBody] Hair hair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hair.HairId)
            {
                return BadRequest();
            }

            _context.Entry(hair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairExists(id))
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

        // POST: api/Hair
        [HttpPost]
        public async Task<IActionResult> PostHair([FromBody] Hair hair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Hair.Add(hair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHair", new { id = hair.HairId }, hair);
        }

        // DELETE: api/Hair/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHair([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hair = await _context.Hair.FindAsync(id);
            if (hair == null)
            {
                return NotFound();
            }

            _context.Hair.Remove(hair);
            await _context.SaveChangesAsync();

            return Ok(hair);
        }

        private bool HairExists(int id)
        {
            return _context.Hair.Any(e => e.HairId == id);
        }
    }
}