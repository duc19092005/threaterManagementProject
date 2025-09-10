using backend.dtos;
using backend.Enums;
using backend.helper;
using backend.response;
using backend.response.AuthResponse;
using Microsoft.AspNetCore.Identity;

namespace backend.services.AuthServices;

public class AuthService : IAuthService
{
    private readonly JwtGeneratorHelper _jwtGeneratorHelper;
    public AuthService(JwtGeneratorHelper jwtGeneratorHelper)
    {
        _jwtGeneratorHelper = jwtGeneratorHelper;
    }
    public GenericResponse<AuthResponseMessage> LoginService(loginDto loginDto)
    {
        var checkingIfUserIsExits = loginDto.password == "123" && loginDto.userName == "admin";
        if (checkingIfUserIsExits)
        {
            // Generate Token
            var getToken = _jwtGeneratorHelper.GenerateToken(Guid.NewGuid().ToString(), loginDto.userName,
                new string[] { "Admin" });

            return new GenericResponse<AuthResponseMessage>()
            {
                message = "Login SuccessFully" ,
                data = getToken ,
                responseCode = statusCodeEnum.Ok
            };
        }
        else
        {
            return new GenericResponse<AuthResponseMessage>()
            {
                message = "Login Status : Error , One or more data is Invalid",
                data = null,
                responseCode = statusCodeEnum.NotFound
            };
        }
        // Check Data In Database For Example
    }
}