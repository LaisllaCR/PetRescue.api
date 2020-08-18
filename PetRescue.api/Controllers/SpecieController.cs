using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize]
    public class SpecieController : ControllerBase
    {
        private readonly ISpecieRepository _specieRepository;

        public SpecieController(ISpecieRepository specieRepository)
        {
            _specieRepository = specieRepository ?? throw new ArgumentNullException(nameof(specieRepository));
        }

        // GET: api/Specie
        [HttpGet]
        public IEnumerable<SpecieDto> GetSpecie()
        {
            try
            {
                return _specieRepository.GetSpecies();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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

                var specie = _specieRepository.GetSpecieByID(id);

                if (specie == null)
                {
                    return NotFound();
                }

                return Ok(specie);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Specie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecie([FromRoute] int id, [FromBody] SpecieDto specie)
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
                _specieRepository.UpdateSpecie(specie);
                _specieRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!SpecieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return NoContent();
        }

        // POST: api/Specie
        [HttpPost]
        public async Task<IActionResult> PostSpecie([FromBody] SpecieDto specie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _specieRepository.InsertSpecie(specie);
                _specieRepository.Save();

                return CreatedAtAction("GetSpecie", new { id = specie.SpecieId }, specie);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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

                var specie = _specieRepository.GetSpecieByID(id);
                if (specie == null)
                {
                    return NotFound();
                }

                _specieRepository.DeleteSpecie(id);
                _specieRepository.Save();

                return Ok(specie);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool SpecieExists(int id)
        {
            try
            {
                return _specieRepository.SpecieExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }        
        }
    }
}