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
    public class ContactSocialMidiaController : BaseController
    {
        // GET: api/ContactSocialMidia
        [HttpGet]
        public IEnumerable<ContactSocialMidiaResource> GetContactSocialMidia()
        {
            try
            {
                return UnityOfWork.ContactSocialMidia.GetContactSocialMidias();

            }
            catch (System.Exception)
            {

                throw;
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

                var contactSocialMidia = UnityOfWork.ContactSocialMidia.GetContactSocialMidiaByID(id);

                if (contactSocialMidia == null)
                {
                    return NotFound();
                }

                return Ok(contactSocialMidia);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/ContactSocialMidia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactSocialMidia([FromRoute] int id, [FromBody] ContactSocialMidiaResource contactSocialMidia)
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
                UnityOfWork.ContactSocialMidia.UpdateContactSocialMidia(contactSocialMidia);
                UnityOfWork.ContactSocialMidia.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactSocialMidiaExists(id))
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

        // POST: api/ContactSocialMidia
        [HttpPost]
        public async Task<IActionResult> PostContactSocialMidia([FromBody] ContactSocialMidiaResource contactSocialMidia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnityOfWork.ContactSocialMidia.InsertContactSocialMidia(contactSocialMidia);
                UnityOfWork.ContactSocialMidia.Save();

                return CreatedAtAction("GetContactSocialMidia", new { id = contactSocialMidia.ContactSocialMidiaId }, contactSocialMidia);
            }
            catch (System.Exception)
            {

                throw;
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

                var contactSocialMidia = UnityOfWork.ContactSocialMidia.GetContactSocialMidiaByID(id);
                if (contactSocialMidia == null)
                {
                    return NotFound();
                }

                UnityOfWork.ContactSocialMidia.DeleteContactSocialMidia(id);
                UnityOfWork.ContactSocialMidia.Save();

                return Ok(contactSocialMidia);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool ContactSocialMidiaExists(int id)
        {
            try
            {
                return UnityOfWork.ContactSocialMidia.ContactSocialMidiaExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}