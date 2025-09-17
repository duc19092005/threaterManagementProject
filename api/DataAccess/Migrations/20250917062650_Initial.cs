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
                    { "13b03e6c-a8d2-4165-9634-508090051e7d", "Movie Manager" },
                    { "2adfc60f-6e26-4785-9b79-09f0f1ae2c90", "Customer" },
                    { "620d4cc7-0ade-4925-abea-ebf0e3b342fe", "Threater Manager" },
                    { "6a0576ad-603c-45b2-9171-cf151102ab8d", "Director" },
                    { "c1ad8e30-7533-47b4-9549-f078801b8a4d", "Cashier" },
                    { "deb8c642-51df-4ef1-a792-7a4495376e18", "System Manager" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "password", "username" },
                values: new object[] { "15d4096c-5e1f-41b1-8cbc-599c890f711a", "$2a$10$MxznQNLgmO.zFyQcaqpEFe9xSyTP2EO1s4IoFKInNmhL.F8XJwakC", "duc19092005@email.com" });

            migrationBuilder.InsertData(
                table: "userRole",
                columns: new[] { "roleId", "userId" },
                values: new object[,]
                {
                    { "2adfc60f-6e26-4785-9b79-09f0f1ae2c90", "15d4096c-5e1f-41b1-8cbc-599c890f711a" },
                    { "6a0576ad-603c-45b2-9171-cf151102ab8d", "15d4096c-5e1f-41b1-8cbc-599c890f711a" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_userRole_roleId",
                table: "userRole",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
