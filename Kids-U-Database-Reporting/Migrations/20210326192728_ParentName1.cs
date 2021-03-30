using Microsoft.EntityFrameworkCore.Migrations;

namespace Kids_U_Database_Reporting.Migrations
{
    public partial class ParentName1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentName1",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentName1",
                table: "Students");
        }
    }
}
