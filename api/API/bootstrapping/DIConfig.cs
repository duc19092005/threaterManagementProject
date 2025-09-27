using backend.helper;
using BussinessLogic.services.AuthServices;

namespace backend.bootstrapping;

public static class DIConfig
{
    public static void AddDIConfig(this IServiceCollection services)
    {
        // Scope 
        services.AddScoped<JwtGeneratorHelper>();
        
        // Scope For Auth
        
        services.AddScoped<IAuthService, AuthService>();
        
        // Scope For VNPAY Helper Class

        services.AddScoped<generateVNPAYURLHelper>();
    }
}