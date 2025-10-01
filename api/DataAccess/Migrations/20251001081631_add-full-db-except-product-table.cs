using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addfulldbexceptproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    cinemaId = table.Column<string>(type: "varchar(100)", nullable: false),
                    cinemaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cinemaAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cinemaHotLineNumber = table.Column<string>(type: "char(10)", nullable: false),
                    cinemaStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.cinemaId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    movieGenreId = table.Column<string>(type: "varchar(100)", nullable: false),
                    movieGenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.movieGenreId);
                });

            migrationBuilder.CreateTable(
                name: "MovieInformation",
                columns: table => new
                {
                    movieId = table.Column<string>(type: "varchar(100)", nullable: false),
                    movieName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    movieImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movieDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movieDirector = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    movieActor = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    movieTrailerUrl = table.Column<string>(type: "varchar(300)", nullable: false),
                    movieDuration = table.Column<int>(type: "int", nullable: false),
                    releaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    movieLanguage = table.Column<string>(type: "varchar(100)", nullable: false),
                    miniAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieInformation", x => x.movieId);
                });

            migrationBuilder.CreateTable(
                name: "PriceForVisualFormats",
                columns: table => new
                {
                    priceId = table.Column<string>(type: "varchar(100)", nullable: false),
                    visualFormatId = table.Column<string>(type: "varchar(100)", nullable: false),
                    priceDetail = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceForVisualFormats", x => x.priceId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleId = table.Column<string>(type: "varchar(100)", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfUserDiscounts",
                columns: table => new
                {
                    typeofUserDiscountId = table.Column<string>(type: "varchar(100)", nullable: false),
                    typeOfUser = table.Column<int>(type: "int", nullable: false),
                    discountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfUserDiscounts", x => x.typeofUserDiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    staffId = table.Column<string>(type: "varchar(100)", nullable: false),
                    staffName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    staffIdentityCode = table.Column<string>(type: "varchar(100)", nullable: false),
                    userId = table.Column<string>(type: "varchar(100)", nullable: false),
                    cinemaId = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.staffId);
                    table.ForeignKey(
                        name: "FK_Staff_Cinemas_cinemaId",
                        column: x => x.cinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "cinemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    genereId = table.Column<string>(type: "varchar(100)", nullable: false),
                    movieId = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.movieId, x.genereId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_genereId",
                        column: x => x.genereId,
                        principalTable: "Genres",
                        principalColumn: "movieGenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_MovieInformation_movieId",
                        column: x => x.movieId,
                        principalTable: "MovieInformation",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisualFormats",
                columns: table => new
                {
                    visualFormatId = table.Column<string>(type: "varchar(100)", nullable: false),
                    visualFormatName = table.Column<string>(type: "char(20)", nullable: false),
                    priceId = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisualFormats", x => x.visualFormatId);
                    table.ForeignKey(
                        name: "FK_VisualFormats_PriceForVisualFormats_priceId",
                        column: x => x.priceId,
                        principalTable: "PriceForVisualFormats",
                        principalColumn: "priceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    roleId = table.Column<string>(type: "varchar(100)", nullable: false),
                    discountNumber = table.Column<double>(type: "float", nullable: false),
                    roleModelroleId = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.roleId);
                    table.ForeignKey(
                        name: "FK_Discounts_Role_roleModelroleId",
                        column: x => x.roleModelroleId,
                        principalTable: "Role",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CinemaRooms",
                columns: table => new
                {
                    cinemaRoomId = table.Column<string>(type: "varchar(100)", nullable: false),
                    cinemaRoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visualFormatId = table.Column<string>(type: "varchar(100)", nullable: false),
                    cinemaId = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaRooms", x => x.cinemaRoomId);
                    table.ForeignKey(
                        name: "FK_CinemaRooms_Cinemas_cinemaId",
                        column: x => x.cinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "cinemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaRooms_VisualFormats_visualFormatId",
                        column: x => x.visualFormatId,
                        principalTable: "VisualFormats",
                        principalColumn: "visualFormatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieVisualFormats",
                columns: table => new
                {
                    movieId = table.Column<string>(type: "varchar(100)", nullable: false),
                    visualFormatId = table.Column<string>(type: "varchar(100)", nullable: false),
                    priceForVisualFormatpriceId = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieVisualFormats", x => new { x.movieId, x.visualFormatId });
                    table.ForeignKey(
                        name: "FK_MovieVisualFormats_MovieInformation_movieId",
                        column: x => x.movieId,
                        principalTable: "MovieInformation",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieVisualFormats_PriceForVisualFormats_priceForVisualFormatpriceId",
                        column: x => x.priceForVisualFormatpriceId,
                        principalTable: "PriceForVisualFormats",
                        principalColumn: "priceId");
                    table.ForeignKey(
                        name: "FK_MovieVisualFormats_VisualFormats_visualFormatId",
                        column: x => x.visualFormatId,
                        principalTable: "VisualFormats",
                        principalColumn: "visualFormatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<string>(type: "varchar(100)", nullable: false),
                    username = table.Column<string>(type: "varchar(150)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false),
                    discountModelroleId = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                    table.ForeignKey(
                        name: "FK_User_Discounts_discountModelroleId",
                        column: x => x.discountModelroleId,
                        principalTable: "Discounts",
                        principalColumn: "roleId");
                });

            migrationBuilder.CreateTable(
                name: "MovieSchedules",
                columns: table => new
                {
                    movieScheduleId = table.Column<string>(type: "varchar(100)", nullable: false),
                    cinemaRoomId = table.Column<string>(type: "varchar(100)", nullable: false),
                    movieId = table.Column<string>(type: "varchar(100)", nullable: false),
                    visualFormatId = table.Column<string>(type: "varchar(100)", nullable: false),
                    dayOfWeek = table.Column<int>(type: "int", nullable: false),
                    hourSchedule = table.Column<int>(type: "int", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSchedules", x => x.movieScheduleId);
                    table.ForeignKey(
                        name: "FK_MovieSchedules_CinemaRooms_cinemaRoomId",
                        column: x => x.cinemaRoomId,
                        principalTable: "CinemaRooms",
                        principalColumn: "cinemaRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSchedules_MovieInformation_movieId",
                        column: x => x.movieId,
                        principalTable: "MovieInformation",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSchedules_VisualFormats_visualFormatId",
                        column: x => x.visualFormatId,
                        principalTable: "VisualFormats",
                        principalColumn: "visualFormatId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    seatsId = table.Column<string>(type: "varchar(100)", nullable: false),
                    seatsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cinemaRommId = table.Column<string>(type: "varchar(100)", nullable: false),
                    seatsStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.seatsId);
                    table.ForeignKey(
                        name: "FK_Seats_CinemaRooms_cinemaRommId",
                        column: x => x.cinemaRommId,
                        principalTable: "CinemaRooms",
                        principalColumn: "cinemaRoomId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<string>(type: "varchar(100)", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    customerPhoneNumber = table.Column<string>(type: "char(10)", nullable: false),
                    customerIdentityNumber = table.Column<string>(type: "varchar(100)", nullable: false),
                    userId = table.Column<string>(type: "varchar(100)", nullable: false)
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
                name: "MovieComments",
                columns: table => new
                {
                    commentId = table.Column<string>(type: "varchar(100)", nullable: false),
                    commentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movieId = table.Column<string>(type: "varchar(100)", nullable: false),
                    userId = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieComments", x => x.commentId);
                    table.ForeignKey(
                        name: "FK_MovieComments_MovieInformation_movieId",
                        column: x => x.movieId,
                        principalTable: "MovieInformation",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieComments_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<string>(type: "varchar(100)", nullable: false),
                    paymentMethod = table.Column<string>(type: "varchar(50)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalAmount = table.Column<long>(type: "bigint", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentRequestCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerID = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Orders_User_customerID",
                        column: x => x.customerID,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userRole",
                columns: table => new
                {
                    userId = table.Column<string>(type: "varchar(100)", nullable: false),
                    roleId = table.Column<string>(type: "varchar(100)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TicketOrderDetails",
                columns: table => new
                {
                    orderId = table.Column<string>(type: "varchar(100)", nullable: false),
                    seatId = table.Column<string>(type: "varchar(100)", nullable: false),
                    movieScheduleID = table.Column<string>(type: "varchar(100)", nullable: false),
                    PriceEach = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOrderDetails", x => new { x.orderId, x.seatId });
                    table.ForeignKey(
                        name: "FK_TicketOrderDetails_MovieSchedules_movieScheduleID",
                        column: x => x.movieScheduleID,
                        principalTable: "MovieSchedules",
                        principalColumn: "movieScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketOrderDetails_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketOrderDetails_Seats_seatId",
                        column: x => x.seatId,
                        principalTable: "Seats",
                        principalColumn: "seatsId",
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
                columns: new[] { "userId", "discountModelroleId", "password", "username" },
                values: new object[] { "00a1b2c3-d4e5-f678-90ab-cdef01234567", null, "$2a$12$PFeVPgS2ffEm1oY6OqldHutsGi0IJnMu3HCc6EUTS1RB32/cZNILy", "duc19092005@email.com" });

            migrationBuilder.InsertData(
                table: "userRole",
                columns: new[] { "roleId", "userId" },
                values: new object[,]
                {
                    { "a1b2c3d4-e5f6-7890-1234-567890abcdef", "00a1b2c3-d4e5-f678-90ab-cdef01234567" },
                    { "b1c2d3e4-f5a6-8901-2345-67890abcdef1", "00a1b2c3-d4e5-f678-90ab-cdef01234567" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRooms_cinemaId",
                table: "CinemaRooms",
                column: "cinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRooms_visualFormatId",
                table: "CinemaRooms",
                column: "visualFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_userId",
                table: "Customer",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_roleId",
                table: "Discounts",
                column: "roleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_roleModelroleId",
                table: "Discounts",
                column: "roleModelroleId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieComments_movieId",
                table: "MovieComments",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieComments_userId",
                table: "MovieComments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_genereId",
                table: "MovieGenres",
                column: "genereId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSchedules_cinemaRoomId",
                table: "MovieSchedules",
                column: "cinemaRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSchedules_movieId",
                table: "MovieSchedules",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSchedules_visualFormatId",
                table: "MovieSchedules",
                column: "visualFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieVisualFormats_priceForVisualFormatpriceId",
                table: "MovieVisualFormats",
                column: "priceForVisualFormatpriceId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieVisualFormats_visualFormatId",
                table: "MovieVisualFormats",
                column: "visualFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerID",
                table: "Orders",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_cinemaRommId",
                table: "Seats",
                column: "cinemaRommId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_cinemaId",
                table: "Staff",
                column: "cinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrderDetails_movieScheduleID",
                table: "TicketOrderDetails",
                column: "movieScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrderDetails_seatId",
                table: "TicketOrderDetails",
                column: "seatId");

            migrationBuilder.CreateIndex(
                name: "IX_User_discountModelroleId",
                table: "User",
                column: "discountModelroleId");

            migrationBuilder.CreateIndex(
                name: "IX_userRole_roleId",
                table: "userRole",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_VisualFormats_priceId",
                table: "VisualFormats",
                column: "priceId");

            migrationBuilder.CreateIndex(
                name: "IX_VisualFormats_visualFormatName",
                table: "VisualFormats",
                column: "visualFormatName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "MovieComments");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MovieVisualFormats");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "TicketOrderDetails");

            migrationBuilder.DropTable(
                name: "TypeOfUserDiscounts");

            migrationBuilder.DropTable(
                name: "userRole");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MovieSchedules");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "MovieInformation");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CinemaRooms");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "VisualFormats");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "PriceForVisualFormats");
        }
    }
}
