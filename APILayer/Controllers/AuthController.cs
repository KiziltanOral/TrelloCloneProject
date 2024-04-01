using APILayer.JwtService;
using APILayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtAuthenticationService _service;

        public AuthController(JwtAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var token = _service.Authenticate(model.Username, model.Password);
            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }
            return Ok(new {Token = token});
        }
    }
}
