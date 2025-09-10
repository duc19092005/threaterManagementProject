using backend.helper;
using backend.services.AuthServices;

namespace backend.bootstrapping;

public static class DIConfig
{
    public static void AddDIConfig(this IServiceCollection services)
    {
        // Scope 
        services.AddScoped<JwtGeneratorHelper>();
        
        // Scope For Auth
        services.AddScoped<IAuthService, AuthService>();
    }
}