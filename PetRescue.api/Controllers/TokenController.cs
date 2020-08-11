using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetRescue.api.Model.DAL.UnitOfWork;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;
using PetRescue.api.Models.Dtos.AppClient;

namespace PetRescue.api.Controllers
{
    [Route("api/[controller]")]
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}