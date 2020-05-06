using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize]
    public class SpecieController : BaseController
    {
        // GET: api/Specie
        [HttpGet]
        public IEnumerable<SpecieResource> GetSpecie()
        {
            try
            {
                return UnitOfWork.Specie.GetSpecies();

            }
            catch (System.Exception)
            {

                throw;
            }     
        }

        // GET: api/Specie/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecie([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var specie = UnitOfWork.Specie.GetSpecieByID(id);

                if (specie == null)
                {
                    return NotFound();
                }

                return Ok(specie);
            }
            catch (System.Exception)
            {

                throw;
            }
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
                UnitOfWork.Specie.UpdateSpecie(specie);
                UnitOfWork.Specie.Save();
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
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Specie.InsertSpecie(specie);
                UnitOfWork.Specie.Save();

                return CreatedAtAction("GetSpecie", new { id = specie.SpecieId }, specie);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE: api/Specie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecie([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var specie = UnitOfWork.Specie.GetSpecieByID(id);
                if (specie == null)
                {
                    return NotFound();
                }

                UnitOfWork.Specie.DeleteSpecie(id);
                UnitOfWork.Specie.Save();

                return Ok(specie);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool SpecieExists(int id)
        {
            try
            {
                return UnitOfWork.Specie.SpecieExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }        
        }
    }
}