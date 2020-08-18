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
    [Authorize]
    public class SizeController : ControllerBase
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeController(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository ?? throw new ArgumentNullException(nameof(sizeRepository));
        }

        // GET: api/Size
        [HttpGet]
        public IEnumerable<SizeDto> GetSize()
        {
            try
            {
                return _sizeRepository.GetSizes();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }     
        }

        // GET: api/Size/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSize([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var size = _sizeRepository.GetSizeByID(id);

                if (size == null)
                {
                    return NotFound();
                }

                return Ok(size);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Size/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSize([FromRoute] int id, [FromBody] SizeDto size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != size.SizeId)
            {
                return BadRequest();
            }
            
            try
            {
                _sizeRepository.UpdateSize(size);
                _sizeRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!SizeExists(id))
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

        // POST: api/Size
        [HttpPost]
        public async Task<IActionResult> PostSize([FromBody] SizeDto size)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _sizeRepository.InsertSize(size); ;
                _sizeRepository.Save();

                return CreatedAtAction("GetSize", new { id = size.SizeId }, size);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Size/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var size = _sizeRepository.GetSizeByID(id);

                if (size == null)
                {
                    return NotFound();
                }

                _sizeRepository.DeleteSize(id);
                _sizeRepository.Save();

                return Ok(size);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool SizeExists(int id)
        {
            try
            {
                return _sizeRepository.SizeExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }      
        }
    }
}