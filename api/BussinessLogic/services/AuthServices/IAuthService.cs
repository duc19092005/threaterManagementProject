using BussinessLogic.dtos;
using BussinessLogic.Result;

namespace BussinessLogic.services.AuthServices;

public interface IAuthService
{
    public Task<AuthenticatedResult> LoginService(
        loginDto loginDto
        );

    public Task<RegisterResult> RegisterService(registerDto registerDto);
}