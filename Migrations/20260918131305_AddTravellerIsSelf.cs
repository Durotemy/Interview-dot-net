using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learning4.Migrations
{
    /// <inheritdoc />
    public partial class AddTravellerIsSelf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelf",
                table: "Travellers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelf",
                table: "Travellers");
        }
    }
}
