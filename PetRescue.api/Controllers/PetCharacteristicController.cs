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
    public class PetCharacteristicController : BaseController
    {
        // GET: api/PetCharacteristic
        [HttpGet]
        public IEnumerable<PetCharacteristicResource> GetPetCharacteristic()
        {
            try
            {
                return UnitOfWork.PetCharacteristic.GetPetCharacteristics();

            }
            catch (System.Exception)
            {

                throw;
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

                var petCharacteristic = UnitOfWork.PetCharacteristic.GetPetCharacteristicByID(id);

                if (petCharacteristic == null)
                {
                    return NotFound();
                }

                return Ok(petCharacteristic);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/PetCharacteristic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetCharacteristic([FromRoute] int id, [FromBody] PetCharacteristicResource petCharacteristic)
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
                UnitOfWork.PetCharacteristic.UpdatePetCharacteristic(petCharacteristic);
                UnitOfWork.PetCharacteristic.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetCharacteristicExists(id))
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

        // POST: api/PetCharacteristic
        [HttpPost]
        public async Task<IActionResult> PostPetCharacteristic([FromBody] PetCharacteristicResource petCharacteristic)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.PetCharacteristic.InsertPetCharacteristic(petCharacteristic);
                UnitOfWork.PetCharacteristic.Save();

                return CreatedAtAction("GetPetCharacteristic", new { id = petCharacteristic.PetCharacteristicId }, petCharacteristic);
            }
            catch (System.Exception)
            {

                throw;
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

                var petCharacteristic = UnitOfWork.PetCharacteristic.GetPetCharacteristicByID(id);
                if (petCharacteristic == null)
                {
                    return NotFound();
                }

                UnitOfWork.PetCharacteristic.DeletePetCharacteristic(id);
                UnitOfWork.PetCharacteristic.Save();

                return Ok(petCharacteristic);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool PetCharacteristicExists(int id)
        {
            try
            {
                return UnitOfWork.PetCharacteristic.PetCharacteristicExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}