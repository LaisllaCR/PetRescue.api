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
    public class PetColorController : BaseController
    {
        // GET: api/PetColor
        [HttpGet]
        public IEnumerable<PetColorResource> GetPetColor()
        {
            try
            {
                return UnitOfWork.PetColor.GetPetColors();

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

                var petColor = UnitOfWork.PetColor.GetPetColorByID(id);

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
        public async Task<IActionResult> PutPetColor([FromRoute] int id, [FromBody] PetColorResource petColor)
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
                UnitOfWork.PetColor.UpdatePetColor(petColor);
                UnitOfWork.PetColor.Save();
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
        public async Task<IActionResult> PostPetColor([FromBody] PetColorResource petColor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.PetColor.InsertPetColor(petColor);
                UnitOfWork.PetColor.Save();

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

                var petColor = UnitOfWork.PetColor.GetPetColorByID(id);
                if (petColor == null)
                {
                    return NotFound();
                }

                UnitOfWork.PetColor.DeletePetColor(id);
                UnitOfWork.PetColor.Save();

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
                return UnitOfWork.PetColor.PetColorExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}