using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetColorController : ControllerBase
    {
        private readonly IPetColorRepository _petColorRepository;

        public PetColorController(IPetColorRepository petColorRepository)
        {
            _petColorRepository = petColorRepository ?? throw new ArgumentNullException(nameof(petColorRepository));
        }

        // GET: api/PetColor
        [HttpGet]
        public IEnumerable<PetColorDto> GetPetColor()
        {
            try
            {
                return _petColorRepository.GetPetColors();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET: api/PetColor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetColor([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var petColor = _petColorRepository.GetPetColorByID(id);

                if (petColor == null)
                {
                    return NotFound();
                }

                return Ok(petColor);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/PetColor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetColor([FromRoute] int id, [FromBody] PetColorDto petColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petColor.PetColorId)
            {
                return BadRequest();
            }

            try
            {
                _petColorRepository.UpdatePetColor(petColor);
                _petColorRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetColorExists(id))
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

        // POST: api/PetColor
        [HttpPost]
        public async Task<IActionResult> PostPetColor([FromBody] PetColorDto petColor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _petColorRepository.InsertPetColor(petColor);
                _petColorRepository.Save();

                return CreatedAtAction("GetPetColor", new { id = petColor.PetColorId }, petColor);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE: api/PetColor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetColor([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var petColor = _petColorRepository.GetPetColorByID(id);
                if (petColor == null)
                {
                    return NotFound();
                }

                _petColorRepository.DeletePetColor(id);
                _petColorRepository.Save();

                return Ok(petColor);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool PetColorExists(int id)
        {
            try
            {
                return _petColorRepository.PetColorExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}