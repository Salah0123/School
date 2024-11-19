using Microsoft.AspNetCore.Mvc;
using School.Api.Services;
using School.Api.Contracts.Authentication;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("")]
        public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            var (authResult, error) = await _authService.GetTokenAsync(request.Phone, request.Password, cancellationToken);
            if(error is not null)
                return BadRequest(error);

            return Ok(authResult);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            var  error = await _authService.RegisterAsync(request, cancellationToken);
            
            if (error is not null)
                return BadRequest(error);

            return Ok();
        }
    }
}