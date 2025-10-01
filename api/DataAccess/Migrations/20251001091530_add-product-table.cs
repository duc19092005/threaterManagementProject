using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<string>(type: "varchar(100)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productImage = table.Column<string>(type: "varchar(max)", nullable: false),
                    productPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "cinemaProductModel",
                columns: table => new
                {
                    cinemaId = table.Column<string>(type: "varchar(100)", nullable: false),
                    productId = table.Column<string>(type: "varchar(100)", nullable: false),
                    productAmount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cinemaProductModel", x => new { x.cinemaId, x.productId });
                    table.ForeignKey(
                        name: "FK_cinemaProductModel_Cinemas_productId",
                        column: x => x.productId,
                        principalTable: "Cinemas",
                        principalColumn: "cinemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cinemaProductModel_Products_cinemaId",
                        column: x => x.cinemaId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodOrderDetails",
                columns: table => new
                {
                    orderId = table.Column<string>(type: "varchar(100)", nullable: false),
                    foodInformationId = table.Column<string>(type: "varchar(100)", nullable: false),
                    quanlity = table.Column<int>(type: "int", nullable: false),
                    PriceEach = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrderDetails", x => new { x.orderId, x.foodInformationId });
                    table.ForeignKey(
                        name: "FK_FoodOrderDetails_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrderDetails_Products_foodInformationId",
                        column: x => x.foodInformationId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cinemaProductModel_productId",
                table: "cinemaProductModel",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrderDetails_foodInformationId",
                table: "FoodOrderDetails",
                column: "foodInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cinemaProductModel");

            migrationBuilder.DropTable(
                name: "FoodOrderDetails");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
