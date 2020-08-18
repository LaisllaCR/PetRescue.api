using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CharacteristicController : ControllerBase
    {
        private readonly ICharacteristicRepository _characteristicRepository;

        public CharacteristicController(ICharacteristicRepository characteristicRepository)
        {
            _characteristicRepository = characteristicRepository ?? throw new ArgumentNullException(nameof(characteristicRepository));
        }
        // GET: api/Characteristic
        [HttpGet]
        public IEnumerable<CharacteristicDto> GetCharacteristic()
        {
            try
            {
                return _characteristicRepository.GetCharacteristics();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: api/Characteristic/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacteristic([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var characteristic = _characteristicRepository.GetCharacteristicByID(id);

                if (characteristic == null)
                {
                    return NotFound();
                }

                return Ok(characteristic);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Characteristic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacteristic([FromRoute] int id, [FromBody] CharacteristicDto characteristic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characteristic.CharacteristicId)
            {
                return BadRequest();
            }

            try
            {
                _characteristicRepository.UpdateCharacteristic(characteristic);
                _characteristicRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CharacteristicExists(id))
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

        // POST: api/Characteristic
        [HttpPost]
        public async Task<IActionResult> PostCharacteristic([FromBody] CharacteristicDto characteristic)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _characteristicRepository.InsertCharacteristic(characteristic);
                _characteristicRepository.Save();

                return CreatedAtAction("GetCharacteristic", new { id = characteristic.CharacteristicId }, characteristic);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Characteristic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacteristic([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var characteristic = _characteristicRepository.GetCharacteristicByID(id);
                if (characteristic == null)
                {
                    return NotFound();
                }

                _characteristicRepository.DeleteCharacteristic(id);
                _characteristicRepository.Save();

                return Ok(characteristic);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool CharacteristicExists(int id)
        {
            try
            {
                return _characteristicRepository.CharacteristicExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}