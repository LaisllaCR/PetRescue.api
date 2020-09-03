using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    [Route("v1/contacts")]
    [ApiController]
    [AllowAnonymous]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }
        // GET: api/Contact
        [HttpGet]
        public IEnumerable<ContactDto> GetContact()
        {
            try
            {
                return _contactRepository.GetContacts();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var contact = _contactRepository.GetContactByID(id);

                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Contact/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact([FromRoute] int id, [FromBody] ContactDto contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactId)
            {
                return BadRequest();
            }

            try
            {
                _contactRepository.UpdateContact(contact);
                _contactRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ContactExists(id))
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

        // POST: api/Contact
        [HttpPost]
        public async Task<IActionResult> PostContact([FromBody] ContactDto contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _contactRepository.InsertContact(contact);
                _contactRepository.Save();

                return CreatedAtAction("GetContact", new { id = contact.ContactId }, contact);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Contact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var contact = _contactRepository.GetContactByID(id);
                if (contact == null)
                {
                    return NotFound();
                }

                _contactRepository.DeleteContact(id);
                _contactRepository.Save();

                return Ok(contact);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool ContactExists(int id)
        {
            try
            {
                return _contactRepository.ContactExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}