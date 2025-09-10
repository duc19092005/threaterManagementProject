using backend.dtos;
using backend.helper;
using backend.response;
using backend.response.AuthResponse;
using backend.services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    // Get Services
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        this._authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(loginDto loginDto)
    {
        // Get Status
        var loginResponseStatus = _authService.LoginService(loginDto);
        return returnHttpResponseHelper<AuthResponseMessage>
            .returnHttpResponse(loginResponseStatus.responseCode , 
                loginResponseStatus);
    }
}