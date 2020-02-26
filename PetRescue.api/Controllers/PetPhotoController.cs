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
    public class PetPhotoController : BaseController
    {
        // GET: api/PetPhoto
        [HttpGet]
        public IEnumerable<PetPhotoResource> GetPetPhoto()
        {
            try
            {
                return UnityOfWork.PetPhoto.GetPetPhotos();

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

                var petPhoto = UnityOfWork.PetPhoto.GetPetPhotoByID(id);

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
        public async Task<IActionResult> PutPetPhoto([FromRoute] int id, [FromBody] PetPhotoResource petPhoto)
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
                UnityOfWork.PetPhoto.UpdatePetPhoto(petPhoto);
                UnityOfWork.PetPhoto.Save();
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
        public async Task<IActionResult> PostPetPhoto([FromBody] PetPhotoResource petPhoto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnityOfWork.PetPhoto.InsertPetPhoto(petPhoto);
                UnityOfWork.PetPhoto.Save();

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

                var petPhoto = UnityOfWork.PetPhoto.GetPetPhotoByID(id);
                if (petPhoto == null)
                {
                    return NotFound();
                }

                UnityOfWork.PetPhoto.DeletePetPhoto(id);
                UnityOfWork.PetPhoto.Save();

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
                return UnityOfWork.PetPhoto.PetPhotoExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}