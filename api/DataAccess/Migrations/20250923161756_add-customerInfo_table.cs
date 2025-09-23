using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addcustomerInfo_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "13b03e6c-a8d2-4165-9634-508090051e7d");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "620d4cc7-0ade-4925-abea-ebf0e3b342fe");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "c1ad8e30-7533-47b4-9549-f078801b8a4d");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "deb8c642-51df-4ef1-a792-7a4495376e18");

            migrationBuilder.DeleteData(
                table: "userRole",
                keyColumns: new[] { "roleId", "userId" },
                keyValues: new object[] { "2adfc60f-6e26-4785-9b79-09f0f1ae2c90", "15d4096c-5e1f-41b1-8cbc-599c890f711a" });

            migrationBuilder.DeleteData(
                table: "userRole",
                keyColumns: new[] { "roleId", "userId" },
                keyValues: new object[] { "6a0576ad-603c-45b2-9171-cf151102ab8d", "15d4096c-5e1f-41b1-8cbc-599c890f711a" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "2adfc60f-6e26-4785-9b79-09f0f1ae2c90");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "6a0576ad-603c-45b2-9171-cf151102ab8d");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: "15d4096c-5e1f-41b1-8cbc-599c890f711a");

            migrationBuilder.CreateTable(
                name: "customerModel",
                columns: table => new
                {
                    customerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "varchar(150)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerModel", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_customerModel_User_userId",
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
                    { "6ae7fd25-7abc-4886-b3d2-7a6bffbbb62b", "Director" },
                    { "77fa1f11-3481-451a-8eba-2586d519f56d", "Movie Manager" },
                    { "b6bc151a-b4b4-41d6-bae4-62ce5627be2f", "Customer" },
                    { "e6380167-8440-4762-b386-3cfa5f0ac9fa", "Cashier" },
                    { "efcddae9-75cf-40e0-be76-8226ea26664e", "Threater Manager" },
                    { "fe4b6c29-b60f-4ea4-a2b8-4b9d6a1c2300", "System Manager" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "password", "username" },
                values: new object[] { "c23a5fa3-ba26-480a-b16c-55cab199e275", "$2a$11$0mufpUUygE3jSNYUKm4f6uj1m3jI7/RlN0MJirBjzuFxdd6iBjZLK", "duc19092005@email.com" });

            migrationBuilder.InsertData(
                table: "userRole",
                columns: new[] { "roleId", "userId" },
                values: new object[,]
                {
                    { "6ae7fd25-7abc-4886-b3d2-7a6bffbbb62b", "c23a5fa3-ba26-480a-b16c-55cab199e275" },
                    { "b6bc151a-b4b4-41d6-bae4-62ce5627be2f", "c23a5fa3-ba26-480a-b16c-55cab199e275" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_customerModel_userId",
                table: "customerModel",
                column: "userId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerModel");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "77fa1f11-3481-451a-8eba-2586d519f56d");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "e6380167-8440-4762-b386-3cfa5f0ac9fa");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "efcddae9-75cf-40e0-be76-8226ea26664e");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "fe4b6c29-b60f-4ea4-a2b8-4b9d6a1c2300");

            migrationBuilder.DeleteData(
                table: "userRole",
                keyColumns: new[] { "roleId", "userId" },
                keyValues: new object[] { "6ae7fd25-7abc-4886-b3d2-7a6bffbbb62b", "c23a5fa3-ba26-480a-b16c-55cab199e275" });

            migrationBuilder.DeleteData(
                table: "userRole",
                keyColumns: new[] { "roleId", "userId" },
                keyValues: new object[] { "b6bc151a-b4b4-41d6-bae4-62ce5627be2f", "c23a5fa3-ba26-480a-b16c-55cab199e275" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "6ae7fd25-7abc-4886-b3d2-7a6bffbbb62b");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "roleId",
                keyValue: "b6bc151a-b4b4-41d6-bae4-62ce5627be2f");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: "c23a5fa3-ba26-480a-b16c-55cab199e275");

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
        }
    }
}
