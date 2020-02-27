﻿using System.Collections.Generic;
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
    [Authorize]
    public class SizeController : BaseController
    {
        // GET: api/Size
        [HttpGet]
        public IEnumerable<SizeResource> GetSize()
        {
            try
            {
                return UnitOfWork.Size.GetSizes();

            }
            catch (System.Exception)
            {

                throw;
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

                var size = UnitOfWork.Size.GetSizeByID(id);

                if (size == null)
                {
                    return NotFound();
                }

                return Ok(size);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/Size/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSize([FromRoute] int id, [FromBody] SizeResource size)
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
                UnitOfWork.Size.UpdateSize(size);
                UnitOfWork.Size.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeExists(id))
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

        // POST: api/Size
        [HttpPost]
        public async Task<IActionResult> PostSize([FromBody] SizeResource size)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.Size.InsertSize(size); ;
                UnitOfWork.Size.Save();

                return CreatedAtAction("GetSize", new { id = size.SizeId }, size);
            }
            catch (System.Exception)
            {

                throw;
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

                var size = UnitOfWork.Size.GetSizeByID(id);

                if (size == null)
                {
                    return NotFound();
                }

                UnitOfWork.Size.DeleteSize(id);
                UnitOfWork.Size.Save();

                return Ok(size);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool SizeExists(int id)
        {
            try
            {
                return UnitOfWork.Size.SizeExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }      
        }
    }
}