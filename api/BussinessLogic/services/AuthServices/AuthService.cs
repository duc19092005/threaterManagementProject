using System.Security.Authentication;
using backend.dbConnection;
using BussinessLogic.customException;
using BussinessLogic.dtos;
using BussinessLogic.Result;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.services.AuthServices;

public class AuthService : IAuthService
{
    private readonly threaterManagementDbContext  _context;
    public AuthService(threaterManagementDbContext context)
    {
        _context = context;
    }
    public async Task<AuthenticatedResult> LoginService(loginDto loginDto)
    {
        // Check User If Exits
        var checkingIfUserIsExits =
            await _context.User.FirstOrDefaultAsync
                (x => x.username.Equals(loginDto.username)
                      );
        
        if (checkingIfUserIsExits != null)
        {
            var checkUserPassword = BCrypt.Net.BCrypt.Verify(loginDto.password, checkingIfUserIsExits.password);
            if (!checkUserPassword)
            {
                throw new AuthException("Invalid username or password");
            }
            // If user Is Exits Continue Checking User Role
            // Check For User Role
            // Get userRoleId
            var userRoleIdList =
                _context.userRole.Where(x => x.userId == checkingIfUserIsExits.userId).Select(x => x.roleId);
            // Get RoleName
            var userRoleNameList =
                await _context.Role.Where(x
                => userRoleIdList.Contains(x.roleId)).Select(x => x.roleName)
                    .ToArrayAsync();
            if (!userRoleNameList.Any())
            {
                throw new AuthException("Role Not Found");
            }
            else
            {
                return new AuthenticatedResult(Guid.NewGuid().ToString()
                    , loginDto.username , userRoleNameList);
            }
            
        }else
        {
            throw new AuthException("Invalid username or password");
        }
    }
}