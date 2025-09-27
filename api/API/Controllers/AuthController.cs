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
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    // Get Services
    private readonly IAuthService _authService;
    
    private readonly generateVNPAYURLHelper _generateVNPAYURLHelper;
    
    private readonly JwtGeneratorHelper _jwtGeneratorHelper;
    

    public AuthController(IAuthService authService , JwtGeneratorHelper jwtGeneratorHelper 
    , generateVNPAYURLHelper generateVNPAYURLHelper)
    {
        this._authService = authService;
        this._jwtGeneratorHelper = jwtGeneratorHelper;
        this._generateVNPAYURLHelper = generateVNPAYURLHelper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(loginDto loginDto)
    {
        try
        {
            var loginStatus = await _authService.LoginService(loginDto);

            // Generate Token

            var generateJwtToken =
                _jwtGeneratorHelper.GenerateToken
                    (loginStatus);
            var returnStatus 
                = GenericResponse<AuthResponseMessage>.LoginSuccessfully(generateJwtToken
                , new string[] {"Add Links In Here"});
            return Ok(returnStatus);
        }
        catch (AuthException ex)
        {
            var FailureStatus =
                GenericResponse<AuthenticationException>.LoginFailure(ex.Message);
            return NotFound(FailureStatus);
        }
        
    }

    [HttpGet("GetVNPAYParams")]
    public IActionResult GetVNPAYParams()
    {
        return Ok(_generateVNPAYURLHelper.generateVnpayURL
        (Guid.NewGuid().ToString(), HttpContext.Request
            .Host.Host, "Order cho don hang so", 20.0));
    }
    
}