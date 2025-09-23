using System.Data;
using backend.model;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace backend.dbConnection;

public class threaterManagementDbContext : DbContext
{
    public threaterManagementDbContext(DbContextOptions<threaterManagementDbContext> options) : base(options)
    {
        
    }

    public  DbSet<userModel> User {get; set;}
    
    public DbSet<userRoleModel> userRole {get; set;} = null!;
    
    public DbSet<roleModel> Role {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        
        var directorId = "6ae7fd25-7abc-4886-b3d2-7a6bffbbb62b";
        var customerId = "b6bc151a-b4b4-41d6-bae4-62ce5627be2f";
        var cashierId = "e6380167-8440-4762-b386-3cfa5f0ac9fa";
        var threaterManagerId = "efcddae9-75cf-40e0-be76-8226ea26664e";
        var systemManagerId = "fe4b6c29-b60f-4ea4-a2b8-4b9d6a1c2300";
        var movieManagerId = "77fa1f11-3481-451a-8eba-2586d519f56d";

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
        var newUserId = "c23a5fa3-ba26-480a-b16c-55cab199e275";
            
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