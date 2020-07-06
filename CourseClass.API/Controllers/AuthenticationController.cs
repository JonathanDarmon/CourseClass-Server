using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CourseClass.API.Models.LoginModel;
using CourseClass.BL.Services.Authentication;

namespace CourseClass.API.Controllers
{

    [Route("api/auth")]
    [Produces("application/json")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        protected readonly IConfiguration _Configuration;

        public AuthenticationController(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model, [FromServices] AuthService _authService)
        {
                object response = _authService.Authenticate(model.Email, model.Password);

                if (response == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);

            
        }
    }
}