using System.Security.Authentication;
using backend.helper;
using backend.response;
using backend.response.AuthResponse;
using Microsoft.AspNetCore.Mvc;
using BussinessLogic.customException;
using BussinessLogic.dtos;
using BussinessLogic.services.AuthServices;
using BussinessLogic.Result;

namespace backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
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
    [HttpPost("register")]
    public async Task<IActionResult> Register(registerDto registerDto)
    {
        try
        {
            var registerResult = await _authService.RegisterService(registerDto);
            
            if (registerResult.IsSuccess)
            {
                // Tạo AuthenticatedResult từ RegisterResult
                var authenticatedResult = new AuthenticatedResult(
                    registerResult.UserId,
                    registerResult.Username,
                    registerResult.Roles
                );
                
                var generateJwtToken = _jwtGeneratorHelper.GenerateToken(authenticatedResult);
                
                var successResponse = GenericResponse<AuthResponseMessage>.LoginSuccessfully(
                    generateJwtToken,
                    new string[] { "Registration successful" }
                );
                
                return Ok(successResponse);
            }
            else
            {
                var failureResponse = GenericResponse<object>.LoginFailure(registerResult.Message);
                return BadRequest(failureResponse);
            }
        }
        catch (RegisterException ex)
        {
            var failureResponse = GenericResponse<object>.LoginFailure(ex.Message);
            return BadRequest(failureResponse);
        }
        catch (Exception ex)
        {
            var failureResponse = GenericResponse<object>.LoginFailure($"Registration failed: {ex.Message}");
            return StatusCode(500, failureResponse);
        }
    }
}