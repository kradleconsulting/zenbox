using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zenbox.data.Migrations
{
    /// <inheritdoc />
    public partial class eventdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Schedules");
        }
    }
}
