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
    public class SocialMidiaController : BaseController
    {
        // GET: api/SocialMidia
        [HttpGet]
        public IEnumerable<SocialMidiaResource> GetSocialMidia()
        {
            try
            {
                return UnityOfWork.SocialMidia.GetSocialMidias();

            }
            catch (System.Exception)
            {

                throw;
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

                var socialMidia = UnityOfWork.SocialMidia.GetSocialMidiaByID(id);

                if (socialMidia == null)
                {
                    return NotFound();
                }

                return Ok(socialMidia);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT: api/SocialMidia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocialMidia([FromRoute] int id, [FromBody] SocialMidiaResource socialMidia)
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
                UnityOfWork.SocialMidia.UpdateSocialMidia(socialMidia);
                UnityOfWork.SocialMidia.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialMidiaExists(id))
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

        // POST: api/SocialMidia
        [HttpPost]
        public async Task<IActionResult> PostSocialMidia([FromBody] SocialMidiaResource socialMidia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UnityOfWork.SocialMidia.InsertSocialMidia(socialMidia); ;
                UnityOfWork.SocialMidia.Save();

                return CreatedAtAction("GetSocialMidia", new { id = socialMidia.SocialMidiaId }, socialMidia);
            }
            catch (System.Exception)
            {

                throw;
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

                var socialMidia = UnityOfWork.SocialMidia.GetSocialMidiaByID(id);

                if (socialMidia == null)
                {
                    return NotFound();
                }

                UnityOfWork.SocialMidia.DeleteSocialMidia(id);
                UnityOfWork.SocialMidia.Save();

                return Ok(socialMidia);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private bool SocialMidiaExists(int id)
        {
            try
            {
                return UnityOfWork.SocialMidia.SocialMidiaExists(id);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}