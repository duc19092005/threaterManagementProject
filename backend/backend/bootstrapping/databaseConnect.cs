using backend.dbConnection;
using Microsoft.EntityFrameworkCore;

namespace backend.bootstrapping;

public static class databaseConnect
{
    public static void connectToDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext
            <dbConnectionHelper>(options => options.UseSqlServer(configuration["MSSQL:connectString"]));
    }
}