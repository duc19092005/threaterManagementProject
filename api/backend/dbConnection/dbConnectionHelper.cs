using System.Data;
using backend.model;
using Microsoft.EntityFrameworkCore;

namespace backend.dbConnection;

public class dbConnectionHelper : DbContext
{
    public dbConnectionHelper(DbContextOptions<dbConnectionHelper> options) : base(options)
    {
        
    }

    private DbSet<userModel> userModel {get; set;}
}