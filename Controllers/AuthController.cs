using Microsoft.AspNetCore.Mvc;
using TravelApi.Dto;
using TravelApi.Services;

namespace TravelApi.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var (result, error) = await _authService.LoginAsync(request);
        if (error != null)
        {
            return Unauthorized(error);
        }
        return Ok(result);
    }
}
