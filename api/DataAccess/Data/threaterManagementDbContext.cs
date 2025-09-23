using System.Data;
using DataAccess.model;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace DataAccess.dbConnection;

public class threaterManagementDbContext : DbContext
{
    public threaterManagementDbContext(DbContextOptions<threaterManagementDbContext> options) : base(options)
    {
        
    }

    public  DbSet<userModel> User {get; set;}
    
    public DbSet<userRoleModel> userRole {get; set;} = null!;
    
    public DbSet<roleModel> Role {get; set;} = null!;
    
    public DbSet<userModel> userModel {get; set;} = null!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        
        var directorId = Guid.NewGuid().ToString();
        var customerId = Guid.NewGuid().ToString();
        var cashierId = Guid.NewGuid().ToString();
        var threaterManagerId = Guid.NewGuid().ToString();
        var systemManagerId = Guid.NewGuid().ToString();
        var movieManagerId = Guid.NewGuid().ToString();

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
        var newUserId = Guid.NewGuid().ToString();
            
        var generateBcryptHashPassword =  
            BCrypt.Net.BCrypt.HashPassword("anhduc9a5");

        modelBuilder.Entity<userModel>().HasData
            (new userModel()
            {
                userId = newUserId,
                username = "duc19092005@email.com",
                password = generateBcryptHashPassword,
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