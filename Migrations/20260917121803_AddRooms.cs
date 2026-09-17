using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learning4.Migrations
{
    /// <inheritdoc />
    public partial class AddRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "RoomsBookings",
                newName: "RoomId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DepartureDate",
                table: "FlightBookings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "FlightBookings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "FlightBookings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "FlightBookings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HotelName = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalRooms = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomsBookings_RoomId",
                table: "RoomsBookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsBookings_Rooms_RoomId",
                table: "RoomsBookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsBookings_Rooms_RoomId",
                table: "RoomsBookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_RoomsBookings_RoomId",
                table: "RoomsBookings");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "FlightBookings");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "RoomsBookings",
                newName: "RoomTypeId");
        }
    }
}
