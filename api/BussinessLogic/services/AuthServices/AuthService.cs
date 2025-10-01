using System.Net;
using System.Security.Authentication;
using BussinessLogic.customException;
using BussinessLogic.dtos;
using BussinessLogic.Result;
using DataAccess.dbConnection;
using DataAccess.model;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BussinessLogic.services.AuthServices;

public class AuthService : IAuthService
{
    private readonly threaterManagementDbContext  _context;
    private readonly ILogger<AuthService> Logger;
    private const string CustomerRoleId = "b1c2d3e4-f5a6-8901-2345-67890abcdef1";
    private readonly AesGcmEncryption _crypto;

    public AuthService(threaterManagementDbContext context , ILogger<AuthService> logger, AesGcmEncryption crypto)
    {
        _context = context;
        Logger = logger;
        _crypto = crypto;
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
         // Begin Transaction
         var transaction = await _context.Database.BeginTransactionAsync();
         try
         {
             if (await _context.User.AnyAsync(u => u.username == registerDto.username))
                 return RegisterResult.Failure(409,"Username already exists");

             if (!string.IsNullOrWhiteSpace(registerDto.phoneNumber) &&
                 await _context.Customer.AnyAsync(c => c.customerPhoneNumber == registerDto.phoneNumber))
                 return RegisterResult.Failure(409,"Phone number already exists");

             var newUserId = Guid.NewGuid().ToString();
             var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.password);
            // Dùng thuật toán khác để mã hóa đi ông
            var encryptedIdentityNumber = !string.IsNullOrWhiteSpace(registerDto.IdentityNumber)
                ? _crypto.Encrypt(registerDto.IdentityNumber)   // Mã hóa 2 chiều
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
                 customerIdentityNumber = encryptedIdentityNumber ?? string.Empty,
             };

             var userRole = new userRoleModel
             {
                 userId = newUserId,
                 roleId = CustomerRoleId
             };

             await _context.User.AddAsync(user);
             await _context.Customer.AddAsync(customer);
             await _context.userRole.AddAsync(userRole);

             await _context.SaveChangesAsync();
             await transaction.CommitAsync();


             return RegisterResult.Success
                 (200, "Registered Successfully");
         }
         catch (DbUpdateException dbEx)
         {
             await transaction.RollbackAsync();
             Logger.LogError(dbEx.Message);
             return RegisterResult.Failure(500, "Database Error");
         }
         catch (Exception ex)
         {
             await transaction.RollbackAsync();

             Logger.LogError(ex.Message);

             return RegisterResult.Failure(500, "System Error Please Try Again Later");
         }
     }
}
