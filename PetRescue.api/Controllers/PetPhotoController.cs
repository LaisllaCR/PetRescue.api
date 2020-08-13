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
    public class PetPhotoController : ControllerBase
    {
        private readonly IPetPhotoRepository _petPhotoRepository;

        public PetPhotoController(IPetPhotoRepository petPhotoRepository)
        {
            _petPhotoRepository = petPhotoRepository ?? throw new ArgumentNullException(nameof(petPhotoRepository));
        }
        // GET: api/PetPhoto
        [HttpGet]
        public IEnumerable<PetPhotoDto> GetPetPhoto()
        {
            try
            {
                return _petPhotoRepository.GetPetPhotos();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET: api/PetPhoto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetPhoto([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var petPhoto = _petPhotoRepository.GetPetPhotoByID(id);

                if (petPhoto == null)
                {
                    return NotFound();
                }

                return Ok(petPhoto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/PetPhoto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetPhoto([FromRoute] int id, [FromBody] PetPhotoDto petPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petPhoto.PetPhotoId)
            {
                return BadRequest();
            }

            try
            {
                _petPhotoRepository.UpdatePetPhoto(petPhoto);
                _petPhotoRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetPhotoExists(id))
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

        // POST: api/PetPhoto
        [HttpPost]
        public async Task<IActionResult> PostPetPhoto([FromBody] PetPhotoDto petPhoto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _petPhotoRepository.InsertPetPhoto(petPhoto);
                _petPhotoRepository.Save();

                return CreatedAtAction("GetPetPhoto", new { id = petPhoto.PetPhotoId }, petPhoto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE: api/PetPhoto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetPhoto([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var petPhoto = _petPhotoRepository.GetPetPhotoByID(id);
                if (petPhoto == null)
                {
                    return NotFound();
                }

                _petPhotoRepository.DeletePetPhoto(id);
                _petPhotoRepository.Save();

                return Ok(petPhoto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool PetPhotoExists(int id)
        {
            try
            {
                return _petPhotoRepository.PetPhotoExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}