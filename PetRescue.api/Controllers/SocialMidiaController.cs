﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;

namespace PetRescue.api.Controllers
{
    [Route("v1/social-midias")]
    [ApiController]
    [Authorize]
    public class SocialMidiaController : ControllerBase
    {
        private readonly ISocialMidiaRepository _socialMidiaRepository;

        public SocialMidiaController(ISocialMidiaRepository socialMidiaRepository)
        {
            _socialMidiaRepository = socialMidiaRepository ?? throw new ArgumentNullException(nameof(socialMidiaRepository));
        }

        // GET: api/SocialMidia
        [HttpGet]
        public IEnumerable<SocialMidiaDto> GetSocialMidia()
        {
            try
            {
                return _socialMidiaRepository.GetSocialMidias();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: api/SocialMidia/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMidia([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var socialMidia = _socialMidiaRepository.GetSocialMidiaByID(id);

                if (socialMidia == null)
                {
                    return NotFound();
                }

                return Ok(socialMidia);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/SocialMidia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocialMidia([FromRoute] int id, [FromBody] SocialMidiaDto socialMidia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != socialMidia.SocialMidiaId)
            {
                return BadRequest();
            }

            try
            {
                _socialMidiaRepository.UpdateSocialMidia(socialMidia);
                _socialMidiaRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!SocialMidiaExists(id))
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

        // POST: api/SocialMidia
        [HttpPost]
        public async Task<IActionResult> PostSocialMidia([FromBody] SocialMidiaDto socialMidia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _socialMidiaRepository.InsertSocialMidia(socialMidia); ;
                _socialMidiaRepository.Save();

                return CreatedAtAction("GetSocialMidia", new { id = socialMidia.SocialMidiaId }, socialMidia);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/SocialMidia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMidia([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var socialMidia = _socialMidiaRepository.GetSocialMidiaByID(id);

                if (socialMidia == null)
                {
                    return NotFound();
                }

                _socialMidiaRepository.DeleteSocialMidia(id);
                _socialMidiaRepository.Save();

                return Ok(socialMidia);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private bool SocialMidiaExists(int id)
        {
            try
            {
                return _socialMidiaRepository.SocialMidiaExists(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}