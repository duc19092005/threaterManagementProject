using System.Security.Authentication;
using BussinessLogic.dtos;
using BussinessLogic.Result;

namespace BussinessLogic.services.AuthServices;

public class AuthService : IAuthService
{

    public AuthService()
    {
        
    }
    public AuthenticatedResult LoginService(loginDto loginDto)
    {
        var checkingIfUserIsExits = 
            loginDto.password == "123" && loginDto.userName == "admin";
        if (checkingIfUserIsExits)
        {
            return new AuthenticatedResult(Guid.NewGuid().ToString()
            , loginDto.userName , new string[]{"Admin"});
        }else
        {
            throw new AuthenticationException("Invalid username or password");
        }
    }
}