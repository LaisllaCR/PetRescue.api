using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AgeController : BaseController
    {
        // GET: api/Age
        [HttpGet]
        public IEnumerable<AgeDto> GetAge()
        {
            try
            {
                return UnitOfWork.Age.GetAges();

            }
            catch (System.Exception)
            {

                throw;
            }  
        }

        // GET: api/Age/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAge([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var age = UnitOfWork.Age.GetAgeByID(id);

                if (age == null)
                {
                    return NotFound();
                }

                return Ok(age);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Age/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAge([FromRoute] int id, [FromBody] AgeDto age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != age.AgeId)
            {
                return BadRequest();
            }
                        
            try
            {
                UnitOfWork.Age.UpdateAge(age);
                UnitOfWork.Age.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeExists(id))
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

        // POST: api/Age
        [HttpPost]
        public async Task<IActionResult> PostAge([FromBody] AgeDto age)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Age.InsertAge(age);
                UnitOfWork.Age.Save();

                return CreatedAtAction("GetAge", new { id = age.AgeId }, age);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE: api/Age/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAge([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var age = UnitOfWork.Age.GetAgeByID(id);
                if (age == null)
                {
                    return NotFound();
                }

                UnitOfWork.Age.DeleteAge(id);
                UnitOfWork.Age.Save();

                return Ok(age);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool AgeExists(int id)
        {
            try
            {
                return UnitOfWork.Age.AgeExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }       
        }
    }
}