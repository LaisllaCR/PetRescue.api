using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    [Route("v1/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
        }

        [HttpGet]
        public IEnumerable<PetDto> GetPet()
        {
            try
            {
                return _petRepository.GetPets();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPet([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var pet = _petRepository.GetPetByID(id);

                if (pet == null)
                {
                    return NotFound();
                }

                return Ok(pet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet([FromRoute] int id, [FromBody] PetDto pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.PetId)
            {
                return BadRequest();
            }

            try
            {
                _petRepository.UpdatePet(pet);
                _petRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!PetExists(id))
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

        [HttpPost]
        public async Task<IActionResult> PostPet([FromBody] PetDto pet)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _petRepository.InsertPet(pet);
                _petRepository.Save();

                return CreatedAtAction("GetPet", new { id = pet.PetId }, pet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var pet = _petRepository.GetPetByID(id);
                if (pet == null)
                {
                    return NotFound();
                }

                _petRepository.DeletePet(id);
                _petRepository.Save();

                return Ok(pet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool PetExists(int id)
        {
            try
            {
                return _petRepository.PetExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}