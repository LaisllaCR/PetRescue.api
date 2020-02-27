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
    public class ColorController : BaseController
    {
        // GET: api/Color
        [HttpGet]
        public IEnumerable<ColorResource> GetColor()
        {
            try
            {
                return UnitOfWork.Color.GetColors();

            }
            catch (System.Exception)
            {

                throw;
            }      
        }

        // GET: api/Color/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColor([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var color = UnitOfWork.Color.GetColorByID(id);

                if (color == null)
                {
                    return NotFound();
                }

                return Ok(color);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Color/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor([FromRoute] int id, [FromBody] ColorResource color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != color.ColorId)
            {
                return BadRequest();
            }

            try
            {
                UnitOfWork.Color.UpdateColor(color);
                UnitOfWork.Color.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        // POST: api/Color
        [HttpPost]
        public async Task<IActionResult> PostColor([FromBody] ColorResource color)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Color.InsertColor(color);
                UnitOfWork.Color.Save();

                return CreatedAtAction("GetColor", new { id = color.ColorId }, color);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE: api/Color/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var color = UnitOfWork.Color.GetColorByID(id);
                if (color == null)
                {
                    return NotFound();
                }

                UnitOfWork.Color.DeleteColor(id);
                UnitOfWork.Color.Save();

                return Ok(color);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool ColorExists(int id)
        {
            try
            {
                return UnitOfWork.Color.ColorExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }   
        }
    }
}