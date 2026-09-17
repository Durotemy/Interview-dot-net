using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learning4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    SecurityConcerns = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TravellerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Meal = table.Column<int>(type: "integer", nullable: false),
                    MealStatus = table.Column<int>(type: "integer", nullable: false),
                    SeatPreference = table.Column<int>(type: "integer", nullable: false),
                    AssignedSeat = table.Column<string>(type: "text", nullable: true),
                    SeatStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightBookings_Travellers_TravellerId",
                        column: x => x.TravellerId,
                        principalTable: "Travellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CheckIn = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckOut = table.Column<DateOnly>(type: "date", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "integer", nullable: false),
                    RoomStatus = table.Column<int>(type: "integer", nullable: false),
                    TravellerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomsBookings_Travellers_TravellerId",
                        column: x => x.TravellerId,
                        principalTable: "Travellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookings_TravellerId",
                table: "FlightBookings",
                column: "TravellerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsBookings_TravellerId",
                table: "RoomsBookings",
                column: "TravellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightBookings");

            migrationBuilder.DropTable(
                name: "RoomsBookings");

            migrationBuilder.DropTable(
                name: "Travellers");
        }
    }
}
