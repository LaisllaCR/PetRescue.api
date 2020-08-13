using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationTypeController : ControllerBase
    {
        private readonly ILocationTypeRepository _locationTypeRepository;

        public LocationTypeController(ILocationTypeRepository locationTypeRepository)
        {
            _locationTypeRepository = locationTypeRepository ?? throw new ArgumentNullException(nameof(locationTypeRepository));
        }

        // GET: api/LocationType
        [HttpGet]
        public IEnumerable<LocationTypeDto> GetLocationType()
        {
            try
            {
                return _locationTypeRepository.GetLocationTypes();

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

                var locationType = _locationTypeRepository.GetLocationTypeByID(id);

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
        public async Task<IActionResult> PutLocationType([FromRoute] int id, [FromBody] LocationTypeDto locationType)
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
                _locationTypeRepository.UpdateLocationType(locationType);
                _locationTypeRepository.Save();
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
        public async Task<IActionResult> PostLocationType([FromBody] LocationTypeDto locationType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _locationTypeRepository.InsertLocationType(locationType);
                _locationTypeRepository.Save();

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

                var locationType = _locationTypeRepository.GetLocationTypeByID(id);
                if (locationType == null)
                {
                    return NotFound();
                }

                _locationTypeRepository.DeleteLocationType(id);
                _locationTypeRepository.Save();

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
                return _locationTypeRepository.LocationTypeExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}