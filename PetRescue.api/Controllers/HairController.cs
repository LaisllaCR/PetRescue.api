using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HairController : BaseController
    {
        // GET: api/Hair
        [HttpGet]
        public IEnumerable<HairResource> GetHair()
        {
            try
            {
                return UnitOfWork.Hair.GetHairs();

            }
            catch (System.Exception)
            {

                throw;
            }       
        }

        // GET: api/Hair/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHair([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var hair = UnitOfWork.Hair.GetHairByID(id);

                if (hair == null)
                {
                    return NotFound();
                }

                return Ok(hair);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Hair/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHair([FromRoute] int id, [FromBody] HairResource hair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hair.HairId)
            {
                return BadRequest();
            }

            try
            {
                UnitOfWork.Hair.UpdateHair(hair);
                UnitOfWork.Hair.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairExists(id))
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

        // POST: api/Hair
        [HttpPost]
        public async Task<IActionResult> PostHair([FromBody] HairResource hair)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Hair.InsertHair(hair);
                UnitOfWork.Hair.Save();

                return CreatedAtAction("GetHair", new { id = hair.HairId }, hair);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE: api/Hair/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHair([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var hair = UnitOfWork.Hair.GetHairByID(id);
                if (hair == null)
                {
                    return NotFound();
                }

                UnitOfWork.Hair.DeleteHair(id);
                UnitOfWork.Hair.Save();

                return Ok(hair);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool HairExists(int id)
        {
            try
            {
                return UnitOfWork.Hair.HairExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }      
        }
    }
}