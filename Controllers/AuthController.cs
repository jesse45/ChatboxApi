using ChatboxApi.Models;
using ChatboxApi.Services.AuthService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => this._authService = authService;

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp([FromBody] UserModel user)
        {
            var session = await this._authService.SignUpUser(user);
            return Ok(session);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserModel user)
        {
            var session = await this._authService.CreateSessionWithUserAuth(user);
            return Ok(session);
        }
    }
}
