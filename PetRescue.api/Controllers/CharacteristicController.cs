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
                return UnitOfWork.Characteristic.GetCharacteristics();

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

                var characteristic = UnitOfWork.Characteristic.GetCharacteristicByID(id);

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
                UnitOfWork.Characteristic.UpdateCharacteristic(characteristic);
                UnitOfWork.Characteristic.Save();
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

                UnitOfWork.Characteristic.InsertCharacteristic(characteristic);
                UnitOfWork.Characteristic.Save();

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

                var characteristic = UnitOfWork.Characteristic.GetCharacteristicByID(id);
                if (characteristic == null)
                {
                    return NotFound();
                }

                UnitOfWork.Characteristic.DeleteCharacteristic(id);
                UnitOfWork.Characteristic.Save();

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
                return UnitOfWork.Characteristic.CharacteristicExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}