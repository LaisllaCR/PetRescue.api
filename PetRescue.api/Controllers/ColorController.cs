using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ColorController : ControllerBase
    {
        private readonly IColorRepository _colorRepository;

        public ColorController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository ?? throw new ArgumentNullException(nameof(colorRepository));
        }
        // GET: api/Color
        [HttpGet]
        public IEnumerable<ColorDto> GetColor()
        {
            try
            {
                return _colorRepository.GetColors();

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

                var color = _colorRepository.GetColorByID(id);

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
        public async Task<IActionResult> PutColor([FromRoute] int id, [FromBody] ColorDto color)
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
                _colorRepository.UpdateColor(color);
                _colorRepository.Save();
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
        public async Task<IActionResult> PostColor([FromBody] ColorDto color)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _colorRepository.InsertColor(color);
                _colorRepository.Save();

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

                var color = _colorRepository.GetColorByID(id);
                if (color == null)
                {
                    return NotFound();
                }

                _colorRepository.DeleteColor(id);
                _colorRepository.Save();

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
                return _colorRepository.ColorExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }   
        }
    }
}