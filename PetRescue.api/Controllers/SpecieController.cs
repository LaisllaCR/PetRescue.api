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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecieController : BaseController
    {
        private readonly dbContext _context;

        public SpecieController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Specie
        [HttpGet]
        public IEnumerable<Specie> GetSpecie()
        {
            return UnityOfWork.Specie.GetSpecies();
        }

        // GET: api/Specie/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specie = UnityOfWork.Specie.GetSpecieByID(id);

            if (specie == null)
            {
                return NotFound();
            }

            return Ok(specie);
        }

        // PUT: api/Specie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecie([FromRoute] int id, [FromBody] Specie specie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specie.ID)
            {
                return BadRequest();
            }

            UnityOfWork.Specie.UpdateSpecie(specie);

            try
            {
                UnityOfWork.Specie.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecieExists(id))
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

        // POST: api/Specie
        [HttpPost]
        public async Task<IActionResult> PostSpecie([FromBody] Specie specie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UnityOfWork.Specie.InsertSpecie(specie);
            UnityOfWork.Specie.Save();

            return CreatedAtAction("GetSpecie", new { id = specie.ID }, specie);
        }

        // DELETE: api/Specie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specie = UnityOfWork.Specie.GetSpecieByID(id);
            if (specie == null)
            {
                return NotFound();
            }

            UnityOfWork.Specie.DeleteSpecie(id);
            UnityOfWork.Specie.Save();

            return Ok(specie);
        }

        private bool SpecieExists(int id)
        {
            return _context.Specie.Any(e => e.ID == id);
        }
    }
}