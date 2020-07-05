using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CourseClass.API.Models.LoginModel;
using CourseClass.BL.Contracts;
using CourseClass.BL.Services;

namespace CourseClass.API.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAdminRepository _repo;
        protected readonly IConfiguration _Configuration;

        public AuthenticationController(IAdminRepository repo, IConfiguration Configuration)
        {

            _repo = repo;
            _Configuration = Configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model, [FromServices] AuthService _authService)
        {
            var response = _authService.Authenticate(model.Email, model.Password);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}