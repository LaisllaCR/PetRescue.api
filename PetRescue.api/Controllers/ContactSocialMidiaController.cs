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
    [AllowAnonymous]
    public class ContactSocialMidiaController : ControllerBase
    {
        private readonly IContactSocialMidiaRepository _contactSocialMidiaRepository;

        public ContactSocialMidiaController(IContactSocialMidiaRepository contactSocialMidiaRepository)
        {
            _contactSocialMidiaRepository = contactSocialMidiaRepository ?? throw new ArgumentNullException(nameof(contactSocialMidiaRepository));
        }

        // GET: api/ContactSocialMidia
        [HttpGet]
        public IEnumerable<ContactSocialMidiaDto> GetContactSocialMidia()
        {
            try
            {
                return _contactSocialMidiaRepository.GetContactSocialMidias();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: api/ContactSocialMidia/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactSocialMidia([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var contactSocialMidia = _contactSocialMidiaRepository.GetContactSocialMidiaByID(id);

                if (contactSocialMidia == null)
                {
                    return NotFound();
                }

                return Ok(contactSocialMidia);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/ContactSocialMidia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactSocialMidia([FromRoute] int id, [FromBody] ContactSocialMidiaDto contactSocialMidia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactSocialMidia.ContactSocialMidiaId)
            {
                return BadRequest();
            }

            try
            {
                _contactSocialMidiaRepository.UpdateContactSocialMidia(contactSocialMidia);
                _contactSocialMidiaRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ContactSocialMidiaExists(id))
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

        // POST: api/ContactSocialMidia
        [HttpPost]
        public async Task<IActionResult> PostContactSocialMidia([FromBody] ContactSocialMidiaDto contactSocialMidia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _contactSocialMidiaRepository.InsertContactSocialMidia(contactSocialMidia);
                _contactSocialMidiaRepository.Save();

                return CreatedAtAction("GetContactSocialMidia", new { id = contactSocialMidia.ContactSocialMidiaId }, contactSocialMidia);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/ContactSocialMidia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactSocialMidia([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var contactSocialMidia = _contactSocialMidiaRepository.GetContactSocialMidiaByID(id);
                if (contactSocialMidia == null)
                {
                    return NotFound();
                }

                _contactSocialMidiaRepository.DeleteContactSocialMidia(id);
                _contactSocialMidiaRepository.Save();

                return Ok(contactSocialMidia);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool ContactSocialMidiaExists(int id)
        {
            try
            {
                return _contactSocialMidiaRepository.ContactSocialMidiaExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}