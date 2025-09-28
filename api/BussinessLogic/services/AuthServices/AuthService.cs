using System.Security.Authentication;
using BussinessLogic.customException;
using BussinessLogic.dtos;
using BussinessLogic.Result;
using DataAccess.dbConnection;
using DataAccess.model;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.services.AuthServices;

public class AuthService : IAuthService
{
    private readonly threaterManagementDbContext  _context;
    private const string CustomerRoleId = "b1c2d3e4-f5a6-8901-2345-67890abcdef1";
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

    public async Task<RegisterResult> RegisterService(registerDto registerDto)
     {
         try
         {
             if (await _context.User.AnyAsync(u => u.username == registerDto.username))
                 return RegisterResult.Failure("Username already exists");
    
             if (!string.IsNullOrWhiteSpace(registerDto.phoneNumber) &&
                         await _context.Customer.AnyAsync(c => c.customerPhoneNumber == registerDto.phoneNumber))
                 return RegisterResult.Failure("Phone number already exists");
    
             var newUserId = Guid.NewGuid().ToString();
             var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.password);
             var hashedIdentityNumber = !string.IsNullOrWhiteSpace(registerDto.IdentityNumber)
                         ? BCrypt.Net.BCrypt.HashPassword(registerDto.IdentityNumber)
                         : null;
    
             var user = new userModel
             {
                 userId = newUserId,
                 username = registerDto.username,
                 password = hashedPassword
             };
    
             var customer = new customerModel
             {
                 customerId = Guid.NewGuid().ToString(), 
                 userId = newUserId,
                 customerName = registerDto.fullName,
                 customerPhoneNumber = registerDto.phoneNumber ?? string.Empty,
                 customerIdentityNumber = hashedIdentityNumber ?? string.Empty,
             };
    
             var userRole = new userRoleModel
             {
                 userId = newUserId,
                 roleId = CustomerRoleId
             };
    
             _context.User.Add(user);
             _context.Customer.Add(customer);
             _context.userRole.Add(userRole);
    
             await _context.SaveChangesAsync();
    
             var userRoles = await _context.Role
                        .Where(r => r.roleId == CustomerRoleId)
                        .Select(r => r.roleName)
                        .ToArrayAsync();
    
             return RegisterResult.Success(newUserId, registerDto.username, registerDto.fullName, userRoles);
         }
         catch (Exception ex)
         {
             return RegisterResult.Failure($"Registration failed: {ex.Message}");
         }
     }
}
