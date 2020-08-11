﻿using System;
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
    public class ContactController : BaseController
    {
        // GET: api/Contact
        [HttpGet]
        public IEnumerable<ContactDto> GetContact()
        {
            try
            {
                return UnitOfWork.Contact.GetContacts();

            }
            catch (System.Exception)
            {

                throw;
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

                var contact = UnitOfWork.Contact.GetContactByID(id);

                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (System.Exception)
            {

                throw;
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
                UnitOfWork.Contact.UpdateContact(contact);
                UnitOfWork.Contact.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

                UnitOfWork.Contact.InsertContact(contact);
                UnitOfWork.Contact.Save();

                return CreatedAtAction("GetContact", new { id = contact.ContactId }, contact);
            }
            catch (System.Exception)
            {

                throw;
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

                var contact = UnitOfWork.Contact.GetContactByID(id);
                if (contact == null)
                {
                    return NotFound();
                }

                UnitOfWork.Contact.DeleteContact(id);
                UnitOfWork.Contact.Save();

                return Ok(contact);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool ContactExists(int id)
        {
            try
            {
                return UnitOfWork.Contact.ContactExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}