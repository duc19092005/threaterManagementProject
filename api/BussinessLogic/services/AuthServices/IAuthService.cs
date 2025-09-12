using BussinessLogic.dtos;
using BussinessLogic.Result;

namespace BussinessLogic.services.AuthServices;

public interface IAuthService
{
    public AuthenticatedResult LoginService(
        loginDto loginDto
        );

    // Add Register Response Services In Here


}