using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Models;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HairController : ControllerBase
    {
        private readonly IHairRepository _hairRepository;

        public HairController(IHairRepository hairRepository)
        {
            _hairRepository = hairRepository ?? throw new ArgumentNullException(nameof(hairRepository));
        }

        // GET: api/Hair
        [HttpGet]
        public IEnumerable<HairDto> GetHair()
        {
            try
            {
                return _hairRepository.GetHairs();

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

                var hair = _hairRepository.GetHairByID(id);

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
        public async Task<IActionResult> PutHair([FromRoute] int id, [FromBody] HairDto hair)
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
                _hairRepository.UpdateHair(hair);
                _hairRepository.Save();
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
        public async Task<IActionResult> PostHair([FromBody] HairDto hair)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _hairRepository.InsertHair(hair);
                _hairRepository.Save();

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

                var hair = _hairRepository.GetHairByID(id);
                if (hair == null)
                {
                    return NotFound();
                }

                _hairRepository.DeleteHair(id);
                _hairRepository.Save();

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
                return _hairRepository.HairExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }      
        }
    }
}