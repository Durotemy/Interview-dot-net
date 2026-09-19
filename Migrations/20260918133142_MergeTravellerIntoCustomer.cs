using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learning4.Migrations
{
    /// <inheritdoc />
    public partial class MergeTravellerIntoCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookings_Travellers_TravellerId",
                table: "FlightBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsBookings_Travellers_TravellerId",
                table: "RoomsBookings");

            migrationBuilder.DropTable(
                name: "Travellers");

            migrationBuilder.RenameColumn(
                name: "TravellerId",
                table: "RoomsBookings",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsBookings_TravellerId",
                table: "RoomsBookings",
                newName: "IX_RoomsBookings_CustomerId");

            migrationBuilder.RenameColumn(
                name: "TravellerId",
                table: "FlightBookings",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightBookings_TravellerId",
                table: "FlightBookings",
                newName: "IX_FlightBookings_CustomerId");

            migrationBuilder.AddColumn<bool>(
                name: "SecurityConcerns",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBookings_Customers_CustomerId",
                table: "FlightBookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsBookings_Customers_CustomerId",
                table: "RoomsBookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookings_Customers_CustomerId",
                table: "FlightBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsBookings_Customers_CustomerId",
                table: "RoomsBookings");

            migrationBuilder.DropColumn(
                name: "SecurityConcerns",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "RoomsBookings",
                newName: "TravellerId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsBookings_CustomerId",
                table: "RoomsBookings",
                newName: "IX_RoomsBookings_TravellerId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "FlightBookings",
                newName: "TravellerId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightBookings_CustomerId",
                table: "FlightBookings",
                newName: "IX_FlightBookings_TravellerId");

            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    IsSelf = table.Column<bool>(type: "boolean", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    SecurityConcerns = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBookings_Travellers_TravellerId",
                table: "FlightBookings",
                column: "TravellerId",
                principalTable: "Travellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsBookings_Travellers_TravellerId",
                table: "RoomsBookings",
                column: "TravellerId",
                principalTable: "Travellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
