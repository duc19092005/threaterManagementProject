using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace backend.bootstrapping;

using Microsoft.AspNetCore.Authentication.JwtBearer;    

public static class jwtConfig
{
    public static void AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:iss"],
                    ValidAudience = configuration["configuration:aud"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration["Jwt:secretKey"]))
                };
            });
    }
}