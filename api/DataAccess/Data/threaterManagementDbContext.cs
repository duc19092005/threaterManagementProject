using System.Data;
using DataAccess.model;
using Microsoft.EntityFrameworkCore;
// Bỏ DevOne.Security.Cryptography.BCrypt; và BCrypt.Net vì chúng không cần thiết cho DbContext

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

    // =======================================================
    // 🌟 KHAI BÁO DBSET CHO TẤT CẢ CÁC ENTITY TRONG THƯ MỤC MODEL 🌟
    // =======================================================

    public DbSet<userModel> User {get; set;}
    public DbSet<userRoleModel> userRole {get; set;} = null!;
    public DbSet<roleModel> Role {get; set;} = null!;
    public DbSet<customerModel> Customer {get; set;} = null!;
    
    // Các DbSet khác dựa trên hình ảnh
    public DbSet<Cinema> Cinemas { get; set; } = null!;
    public DbSet<cinemaRoomModel> CinemaRooms { get; set; } = null!;
    public DbSet<discountModel> Discounts { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<movieComment> MovieComments { get; set; } = null!;
    public DbSet<movieGenre> MovieGenres { get; set; } = null!;
    public DbSet<movieInformation> MovieInformation { get; set; } = null!;
    public DbSet<movieSchedule> MovieSchedules { get; set; } = null!;
    public DbSet<movieVisualFormat> MovieVisualFormats { get; set; } = null!;
    public DbSet<orderModel> Orders { get; set; } = null!;
    public DbSet<priceForVisualFormat> PriceForVisualFormats { get; set; } = null!;
    public DbSet<seatsModel> Seats { get; set; } = null!;
    public DbSet<staffModel> Staff { get; set; } = null!;
    public DbSet<ticketOrderDetail> TicketOrderDetails { get; set; } = null!;
    public DbSet<typeofUserDiscountModel> TypeOfUserDiscounts { get; set; } = null!;
    public DbSet<visualFormat> VisualFormats { get; set; } = null!;
    public DbSet<productModel> Products { get; set; } = null!;
    public DbSet<foodOrderDetail> FoodOrderDetails { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // =======================================================
        // 3. SEEDING DỮ LIỆU BAN ĐẦU
        // =======================================================
        
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
                // Mật khẩu đã được hash sẵn
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