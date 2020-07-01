using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Job_Portal.WebAPI.Models;
using Job_Portal.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegistartionService _registrationService;

        public RegistrationController(IRegistartionService registrationService)
        {
            _registrationService = registrationService;
        }


        [AllowAnonymous]
        [HttpPost("user")]
        public IActionResult Users([FromBody] UserRegistration userRegistration)
        {
            var user = _registrationService.User(userRegistration);
            return Ok(user);
        }
    }
}
