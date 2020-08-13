using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BreedController : ControllerBase
    {
        private readonly IBreedRepository _breedRepository;

        public BreedController(IBreedRepository breedRepository)
        {
            _breedRepository = breedRepository ?? throw new ArgumentNullException(nameof(breedRepository));
        }
        // GET: api/Breed
        [HttpGet]
        public IEnumerable<BreedDto> GetBreed()
        {
            try
            {
                return _breedRepository.GetBreeds();

            }
            catch (System.Exception)
            {

                throw;
            }    
        }

        // GET: api/Breed/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreed([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var breed = _breedRepository.GetBreedByID(id);

                if (breed == null)
                {
                    return NotFound();
                }

                return Ok(breed);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Breed/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreed([FromRoute] int id, [FromBody] BreedDto breed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != breed.BreedId)
            {
                return BadRequest();
            }
            
            try
            {
                _breedRepository.UpdateBreed(breed);
                _breedRepository.Save();
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
        public async Task<IActionResult> PostBreed([FromBody] BreedDto breed)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _breedRepository.InsertBreed(breed);
                _breedRepository.Save();

                return CreatedAtAction("GetBreed", new { id = breed.BreedId }, breed);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Breed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var breed = _breedRepository.GetBreedByID(id);

                if (breed == null)
                {
                    return NotFound();
                }

                _breedRepository.DeleteBreed(id);
                _breedRepository.Save();

                return Ok(breed);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool BreedExists(int id)
        {
            try
            {
                return _breedRepository.BreedExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }       
        }
    }
}