using System.Data;
using backend.model;
using Microsoft.EntityFrameworkCore;

namespace backend.dbConnection;

public class threaterManagementDbContext : DbContext
{
    public threaterManagementDbContext(DbContextOptions<threaterManagementDbContext> options) : base(options)
    {
        
    }

    public  DbSet<userModel> userModel {get; set;}
}