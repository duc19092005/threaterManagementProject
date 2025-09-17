using System.Security.Claims;
using backend.Enums;
using backend.response;

namespace backend.helper;

public class getJwtClaimsHelper
{
    public static jwtClaimsResponse? GetClaims(HttpContext httpContext)
    {
        var getUserClaims = httpContext.User.Claims;
        var userClaims = getUserClaims.ToList();
        if (userClaims.Any())
        {
            // Get User Roles
            var getUserRolesClaims = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            var getUserId =  userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var getUserEmail = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email);

            if (getUserRolesClaims == null)
            {
                return null;
            }else if (getUserId == null)
            {
                return null;
            }else if (getUserEmail == null)
            {
                return null;
            }

            return new jwtClaimsResponse()
            {
                userEmail = getUserEmail.Value,
                userId = getUserId.Value,
                userRoles = getUserRolesClaims.Value.Split(','),
            };

        }

        return null;
    }
}