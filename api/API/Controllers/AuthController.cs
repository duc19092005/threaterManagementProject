using System.Security.Authentication;
using backend.helper;
using backend.response;
using backend.response.AuthResponse;
using Microsoft.AspNetCore.Mvc;
using BussinessLogic.customException;
using BussinessLogic.dtos;
using BussinessLogic.services.AuthServices;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    // Get Services
    private readonly IAuthService _authService;
    
    private readonly JwtGeneratorHelper _jwtGeneratorHelper;
    

    public AuthController(IAuthService authService , JwtGeneratorHelper jwtGeneratorHelper)
    {
        this._authService = authService;
        this._jwtGeneratorHelper = jwtGeneratorHelper;
    }

    [HttpPost("login")]
    public IActionResult Login(loginDto loginDto)
    {
        try
        {
            var loginStatus = _authService.LoginService(loginDto);
            
            // Generate Token

            var generateJwtToken =
                _jwtGeneratorHelper.GenerateToken
                    (loginStatus);
            
            return Ok(generateJwtToken);
        }
        catch (AuthenticationException ex)
        {
            return NotFound(ex.Message);
        }
        
    }
}