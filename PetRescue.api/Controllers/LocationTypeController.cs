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
                return UnityOfWork.LocationType.GetLocationTypes();

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

                var locationType = UnityOfWork.LocationType.GetLocationTypeByID(id);

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
                UnityOfWork.LocationType.UpdateLocationType(locationType);
                UnityOfWork.LocationType.Save();
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

                UnityOfWork.LocationType.InsertLocationType(locationType);
                UnityOfWork.LocationType.Save();

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

                var locationType = UnityOfWork.LocationType.GetLocationTypeByID(id);
                if (locationType == null)
                {
                    return NotFound();
                }

                UnityOfWork.LocationType.DeleteLocationType(id);
                UnityOfWork.LocationType.Save();

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
                return UnityOfWork.LocationType.LocationTypeExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}