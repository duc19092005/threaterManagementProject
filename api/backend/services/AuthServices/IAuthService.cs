using backend.dtos;
using backend.response;
using backend.response.AuthResponse;

namespace backend.services.AuthServices;

public interface IAuthService
{
    GenericResponse<AuthResponseMessage> LoginService(loginDto loginDto);
    
    // Add Register Response Services In Here
    
    
}