using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleId = table.Column<string>(type: "varchar(150)", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<string>(type: "varchar(150)", nullable: false),
                    username = table.Column<string>(type: "varchar(150)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    customerPhoneNumber = table.Column<string>(type: "char(10)", nullable: false),
                    customerIdentityNumber = table.Column<string>(type: "varchar(100)", nullable: false),
                    userId = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customer_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userRole",
                columns: table => new
                {
                    userId = table.Column<string>(type: "varchar(150)", nullable: false),
                    roleId = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRole", x => new { x.userId, x.roleId });
                    table.ForeignKey(
                        name: "FK_userRole_Role_roleId",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRole_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "roleId", "roleName" },
                values: new object[,]
                {
                    { "a1b2c3d4-e5f6-7890-1234-567890abcdef", "Director" },
                    { "b1c2d3e4-f5a6-8901-2345-67890abcdef1", "Customer" },
                    { "c1d2e3f4-g5h6-9012-3456-7890abcdef12", "Cashier" },
                    { "d1e2f3g4-h5i6-0123-4567-890abcdef123", "Threater Manager" },
                    { "e1f2g3h4-i5j6-1234-5678-90abcdef1234", "System Manager" },
                    { "f1g2h3i4-j5k6-2345-6789-0abcdef12345", "Movie Manager" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "password", "username" },
                values: new object[] { "00a1b2c3-d4e5-f678-90ab-cdef01234567", "$2a$12$PFeVPgS2ffEm1oY6OqldHutsGi0IJnMu3HCc6EUTS1RB32/cZNILy", "duc19092005@email.com" });

            migrationBuilder.InsertData(
                table: "userRole",
                columns: new[] { "roleId", "userId" },
                values: new object[,]
                {
                    { "a1b2c3d4-e5f6-7890-1234-567890abcdef", "00a1b2c3-d4e5-f678-90ab-cdef01234567" },
                    { "b1c2d3e4-f5a6-8901-2345-67890abcdef1", "00a1b2c3-d4e5-f678-90ab-cdef01234567" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_userId",
                table: "Customer",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userRole_roleId",
                table: "userRole",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "userRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
