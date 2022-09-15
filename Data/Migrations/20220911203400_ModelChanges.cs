using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCause.Data.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_Courses_CourseSelectedId",
                table: "StudentRegistrations");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseSelectedId",
                table: "StudentRegistrations",
                newName: "PracticalId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRegistrations_CourseSelectedId",
                table: "StudentRegistrations",
                newName: "IX_StudentRegistrations_PracticalId");

            migrationBuilder.CreateTable(
                name: "Practicals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practicals", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_Practicals_PracticalId",
                table: "StudentRegistrations",
                column: "PracticalId",
                principalTable: "Practicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_Practicals_PracticalId",
                table: "StudentRegistrations");

            migrationBuilder.DropTable(
                name: "Practicals");

            migrationBuilder.RenameColumn(
                name: "PracticalId",
                table: "StudentRegistrations",
                newName: "CourseSelectedId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRegistrations_PracticalId",
                table: "StudentRegistrations",
                newName: "IX_StudentRegistrations_CourseSelectedId");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxSize = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_Courses_CourseSelectedId",
                table: "StudentRegistrations",
                column: "CourseSelectedId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
