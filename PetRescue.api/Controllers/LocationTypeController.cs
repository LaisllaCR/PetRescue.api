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
    public class LocationTypeController : BaseController
    {
        // GET: api/LocationType
        [HttpGet]
        public IEnumerable<LocationTypeResource> GetLocationType()
        {
            try
            {
                return UnitOfWork.LocationType.GetLocationTypes();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET: api/LocationType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationType([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var locationType = UnitOfWork.LocationType.GetLocationTypeByID(id);

                if (locationType == null)
                {
                    return NotFound();
                }

                return Ok(locationType);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/LocationType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationType([FromRoute] int id, [FromBody] LocationTypeResource locationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locationType.LocationTypeId)
            {
                return BadRequest();
            }

            try
            {
                UnitOfWork.LocationType.UpdateLocationType(locationType);
                UnitOfWork.LocationType.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationTypeExists(id))
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

        // POST: api/LocationType
        [HttpPost]
        public async Task<IActionResult> PostLocationType([FromBody] LocationTypeResource locationType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnitOfWork.LocationType.InsertLocationType(locationType);
                UnitOfWork.LocationType.Save();

                return CreatedAtAction("GetLocationType", new { id = locationType.LocationTypeId }, locationType);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE: api/LocationType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationType([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var locationType = UnitOfWork.LocationType.GetLocationTypeByID(id);
                if (locationType == null)
                {
                    return NotFound();
                }

                UnitOfWork.LocationType.DeleteLocationType(id);
                UnitOfWork.LocationType.Save();

                return Ok(locationType);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool LocationTypeExists(int id)
        {
            try
            {
                return UnitOfWork.LocationType.LocationTypeExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}