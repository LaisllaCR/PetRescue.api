using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetCharacteristicController : ControllerBase
    {
        private readonly IPetCharacteristicRepository _petCharacteristicRepository;

        public PetCharacteristicController(IPetCharacteristicRepository petCharacteristicRepository)
        {
            _petCharacteristicRepository = petCharacteristicRepository ?? throw new ArgumentNullException(nameof(petCharacteristicRepository));
        }

        // GET: api/PetCharacteristic
        [HttpGet]
        public IEnumerable<PetCharacteristicDto> GetPetCharacteristic()
        {
            try
            {
                return _petCharacteristicRepository.GetPetCharacteristics();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: api/PetCharacteristic/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetCharacteristic([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var petCharacteristic = _petCharacteristicRepository.GetPetCharacteristicByID(id);

                if (petCharacteristic == null)
                {
                    return NotFound();
                }

                return Ok(petCharacteristic);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/PetCharacteristic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetCharacteristic([FromRoute] int id, [FromBody] PetCharacteristicDto petCharacteristic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petCharacteristic.PetCharacteristicId)
            {
                return BadRequest();
            }

            try
            {
                _petCharacteristicRepository.UpdatePetCharacteristic(petCharacteristic);
                _petCharacteristicRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!PetCharacteristicExists(id))
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

        // POST: api/PetCharacteristic
        [HttpPost]
        public async Task<IActionResult> PostPetCharacteristic([FromBody] PetCharacteristicDto petCharacteristic)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _petCharacteristicRepository.InsertPetCharacteristic(petCharacteristic);
                _petCharacteristicRepository.Save();

                return CreatedAtAction("GetPetCharacteristic", new { id = petCharacteristic.PetCharacteristicId }, petCharacteristic);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/PetCharacteristic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetCharacteristic([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var petCharacteristic = _petCharacteristicRepository.GetPetCharacteristicByID(id);
                if (petCharacteristic == null)
                {
                    return NotFound();
                }

                _petCharacteristicRepository.DeletePetCharacteristic(id);
                _petCharacteristicRepository.Save();

                return Ok(petCharacteristic);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool PetCharacteristicExists(int id)
        {
            try
            {
                return _petCharacteristicRepository.PetCharacteristicExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}