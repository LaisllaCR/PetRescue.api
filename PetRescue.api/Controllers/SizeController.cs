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
    public class SizeController : ControllerBase
    {
        private readonly dbContext _context;

        public SizeController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Size
        [HttpGet]
        public IEnumerable<Size> GetSize()
        {
            return _context.Size;
        }

        // GET: api/Size/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSize([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var size = await _context.Size.FindAsync(id);

            if (size == null)
            {
                return NotFound();
            }

            return Ok(size);
        }

        // PUT: api/Size/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSize([FromRoute] int id, [FromBody] Size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != size.ID)
            {
                return BadRequest();
            }

            _context.Entry(size).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeExists(id))
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

        // POST: api/Size
        [HttpPost]
        public async Task<IActionResult> PostSize([FromBody] Size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Size.Add(size);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSize", new { id = size.ID }, size);
        }

        // DELETE: api/Size/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var size = await _context.Size.FindAsync(id);
            if (size == null)
            {
                return NotFound();
            }

            _context.Size.Remove(size);
            await _context.SaveChangesAsync();

            return Ok(size);
        }

        private bool SizeExists(int id)
        {
            return _context.Size.Any(e => e.ID == id);
        }
    }
}