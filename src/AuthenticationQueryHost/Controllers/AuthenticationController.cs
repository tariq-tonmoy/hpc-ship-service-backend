using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShipService.External.AuthenticationQueryHost.Abstractions;
using ShipService.External.AuthenticationQueryHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.External.AuthenticationQueryHost.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServiceProvider authService;

        public AuthenticationController(IAuthenticationServiceProvider authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthQuery query)
        {
            var resp = this.authService.Authenticate(query);

            return this.Ok(resp);
        }
    }
}
