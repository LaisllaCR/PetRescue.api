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
    [Route("v1/pelages")]
    [ApiController]
    [Authorize]
    public class PelageController : ControllerBase
    {
        private readonly IPelageRepository _pelageRepository;

        public PelageController(IPelageRepository pelageRepository)
        {
            _pelageRepository = pelageRepository ?? throw new ArgumentNullException(nameof(pelageRepository));
        }

        // GET: api/Pelage
        [HttpGet]
        public IEnumerable<PelageDto> GetPelage()
        {
            try
            {
                return _pelageRepository.GetPelages();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }       
        }

        // GET: api/Pelage/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPelage([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var pelage = _pelageRepository.GetPelageByID(id);

                if (pelage == null)
                {
                    return NotFound();
                }

                return Ok(pelage);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Pelage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPelage([FromRoute] int id, [FromBody] PelageDto pelage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pelage.HairId)
            {
                return BadRequest();
            }

            try
            {
                _pelageRepository.UpdatePelage(pelage);
                _pelageRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!PelageExists(id))
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

        // POST: api/Pelage
        [HttpPost]
        public async Task<IActionResult> PostPelage([FromBody] PelageDto pelage)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _pelageRepository.InsertPelage(pelage);
                _pelageRepository.Save();

                return CreatedAtAction("GetPelage", new { id = pelage.HairId }, pelage);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Pelage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePelage([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var pelage = _pelageRepository.GetPelageByID(id);
                if (pelage == null)
                {
                    return NotFound();
                }

                _pelageRepository.DeletePelage(id);
                _pelageRepository.Save();

                return Ok(pelage);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool PelageExists(int id)
        {
            try
            {
                return _pelageRepository.PelageExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }      
        }
    }
}