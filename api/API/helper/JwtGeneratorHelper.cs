using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.response.AuthResponse;
using Microsoft.IdentityModel.Tokens;
using BussinessLogic.Result;

namespace backend.helper;

public class JwtGeneratorHelper
{
    private readonly IConfiguration _configuration;
    
    public JwtGeneratorHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public AuthResponseMessage GenerateToken(AuthenticatedResult 
        authenticatedResult
        )
    {
        // _configuration["Jwt:secretKey"], _configuration["Jwt:iss"], _configuration["Jwt:aud"]
        var jwtKey = _configuration["Jwt:secretKey"];
        var jwtIssuer = _configuration["Jwt:iss"];
        var jwtAudience = _configuration["Jwt:aud"];
        // Generate Claims Payload
        var userClaims = new  List<Claim>()
        {
            new Claim(ClaimTypes.Email, authenticatedResult.username),
            new Claim(ClaimTypes.NameIdentifier, authenticatedResult.userId)
        };

        foreach (var role in authenticatedResult.roles)
        {
            userClaims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        // Tạo header
        var SigningCreatical = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        var Hour = DateTime.Now.AddHours(1);
        // Tạo JWT_Token
        var genrateTokenString = new JwtSecurityToken
        (issuer: jwtIssuer,
            audience: jwtAudience,
            userClaims, 
            DateTime.Now,
            Hour, SigningCreatical
        );

        var gettingToken = new JwtSecurityTokenHandler().WriteToken(genrateTokenString);
        
        return new AuthResponseMessage()
        {
            userToken = gettingToken ,
            expiration = Hour.ToLongTimeString()
        };
    }
}