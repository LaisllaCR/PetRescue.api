using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model;
using PetRescue.api.Model.DAL.UnitOfWork;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SpecieController : BaseController
    {
        // GET: api/Specie
        [HttpGet]
        public IEnumerable<SpecieResource> GetSpecie()
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
        public async Task<IActionResult> PutSpecie([FromRoute] int id, [FromBody] SpecieResource specie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specie.SpecieId)
            {
                return BadRequest();
            }


            try
            {
                UnityOfWork.Specie.UpdateSpecie(specie);
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
        public async Task<IActionResult> PostSpecie([FromBody] SpecieResource specie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UnityOfWork.Specie.InsertSpecie(specie);
            UnityOfWork.Specie.Save();

            return CreatedAtAction("GetSpecie", new { id = specie.SpecieId }, specie);
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
            return UnityOfWork.Specie.SpecieExists(id);
        }
    }
}