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
    public class FeatureController : ControllerBase
    {
        private readonly dbContext _context;

        public FeatureController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Feature
        [HttpGet]
        public IEnumerable<Feature> GetFeature()
        {
            return _context.Feature;
        }

        // GET: api/Feature/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feature = await _context.Feature.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            return Ok(feature);
        }

        // PUT: api/Feature/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeature([FromRoute] int id, [FromBody] Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feature.ID)
            {
                return BadRequest();
            }

            _context.Entry(feature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
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

        // POST: api/Feature
        [HttpPost]
        public async Task<IActionResult> PostFeature([FromBody] Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Feature.Add(feature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeature", new { id = feature.ID }, feature);
        }

        // DELETE: api/Feature/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feature = await _context.Feature.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            _context.Feature.Remove(feature);
            await _context.SaveChangesAsync();

            return Ok(feature);
        }

        private bool FeatureExists(int id)
        {
            return _context.Feature.Any(e => e.ID == id);
        }
    }
}