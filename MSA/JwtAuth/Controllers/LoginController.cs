using JwtAuth.Models;
using JwtAuth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;

        public LoginController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var tokenResult = _jwtTokenService.GenerateAuthToken(request);

            return string.IsNullOrEmpty(tokenResult.Token)?
                Unauthorized() : Ok(tokenResult);
        }
    }
}
