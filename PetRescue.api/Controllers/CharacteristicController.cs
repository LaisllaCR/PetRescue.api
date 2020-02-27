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
    [AllowAnonymous]
    public class CharacteristicController : BaseController
    {
        // GET: api/Characteristic
        [HttpGet]
        public IEnumerable<CharacteristicResource> GetCharacteristic()
        {
            try
            {
                return UnityOfWork.Characteristic.GetCharacteristics();

            }
            catch (System.Exception)
            {

                throw;
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

                var characteristic = UnityOfWork.Characteristic.GetCharacteristicByID(id);

                if (characteristic == null)
                {
                    return NotFound();
                }

                return Ok(characteristic);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Characteristic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacteristic([FromRoute] int id, [FromBody] CharacteristicResource characteristic)
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
                UnityOfWork.Characteristic.UpdateCharacteristic(characteristic);
                UnityOfWork.Characteristic.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacteristicExists(id))
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

        // POST: api/Characteristic
        [HttpPost]
        public async Task<IActionResult> PostCharacteristic([FromBody] CharacteristicResource characteristic)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnityOfWork.Characteristic.InsertCharacteristic(characteristic);
                UnityOfWork.Characteristic.Save();

                return CreatedAtAction("GetCharacteristic", new { id = characteristic.CharacteristicId }, characteristic);
            }
            catch (System.Exception)
            {

                throw;
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

                var characteristic = UnityOfWork.Characteristic.GetCharacteristicByID(id);
                if (characteristic == null)
                {
                    return NotFound();
                }

                UnityOfWork.Characteristic.DeleteCharacteristic(id);
                UnityOfWork.Characteristic.Save();

                return Ok(characteristic);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool CharacteristicExists(int id)
        {
            try
            {
                return UnityOfWork.Characteristic.CharacteristicExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}