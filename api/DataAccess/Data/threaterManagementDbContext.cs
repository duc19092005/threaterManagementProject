using System.Data;
using DataAccess.model;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace DataAccess.dbConnection;

public class threaterManagementDbContext : DbContext
{
    // Define static GUIDs for roles
    private static readonly string directorId = "a1b2c3d4-e5f6-7890-1234-567890abcdef";
    private static readonly string customerId = "b1c2d3e4-f5a6-8901-2345-67890abcdef1";
    private static readonly string cashierId = "c1d2e3f4-g5h6-9012-3456-7890abcdef12";
    private static readonly string threaterManagerId = "d1e2f3g4-h5i6-0123-4567-890abcdef123";
    private static readonly string systemManagerId = "e1f2g3h4-i5j6-1234-5678-90abcdef1234";
    private static readonly string movieManagerId = "f1g2h3i4-j5k6-2345-6789-0abcdef12345";
    private static readonly string newUserId = "00a1b2c3-d4e5-f678-90ab-cdef01234567";

    public threaterManagementDbContext(DbContextOptions<threaterManagementDbContext> options) : base(options)
    {
        
    }

    public  DbSet<userModel> User {get; set;}
    
    public DbSet<userRoleModel> userRole {get; set;} = null!;
    
    public DbSet<roleModel> Role {get; set;} = null!;
    
    public DbSet<customerModel> Customer {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        
        modelBuilder.Entity<roleModel>().HasData
            (
                new roleModel[]
                {
                    new roleModel()
                    {
                        roleId = directorId,
                        roleName = "Director"
                    },
                    new roleModel()
                    {
                        roleId = customerId,
                        roleName = "Customer"
                    },
                    new roleModel()
                    {
                        roleId = threaterManagerId,
                        roleName = "Threater Manager"
                    },
                    new roleModel()
                    {
                        roleId = systemManagerId,
                        roleName = "System Manager"
                    },
                    new roleModel()
                    {
                        roleId = movieManagerId,
                        roleName = "Movie Manager"
                    },
                    new roleModel()
                    {
                        roleId = cashierId,
                        roleName = "Cashier"
                    }
                }    
            );
            
        // Add A New User
        modelBuilder.Entity<userModel>().HasData
            (new userModel()
            {
                userId = newUserId,
                username = "duc19092005@email.com",
                password = "$2a$12$PFeVPgS2ffEm1oY6OqldHutsGi0IJnMu3HCc6EUTS1RB32/cZNILy",
            });
        // Add new User Role
        modelBuilder.Entity<userRoleModel>().HasData
            (new userRoleModel()
            {
                userId = newUserId,
                roleId = directorId,
            } , new userRoleModel()
            {
                userId = newUserId,
                roleId = customerId,
            });
    }
}