using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducalProjectT210.Migrations
{
    public partial class categoryChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoryİd",
                table: "Course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoryİd",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
