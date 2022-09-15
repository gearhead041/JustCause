using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCause.Data.Migrations
{
    public partial class levelColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "StudentRegistrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "StudentRegistrations");
        }
    }
}
