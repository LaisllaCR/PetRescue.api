using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetRescue.api.Models.Interfaces;
using PetRescue.api.Models.Dtos.AppClient;

namespace PetRescue.api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        private IAppClientRepository AppClientRepository;

        public TokenController(IAppClientRepository appClientRepository)
        {
            AppClientRepository = appClientRepository;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody]AppClientDto resource)
        {
            try
            {
                var token = AppClientRepository.Authenticate(resource);

                if (token == null)
                    return BadRequest(new { message = "ClientId or Secret is incorrect" });

                return Ok(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}