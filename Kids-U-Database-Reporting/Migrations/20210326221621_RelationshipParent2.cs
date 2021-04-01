using Microsoft.EntityFrameworkCore.Migrations;

namespace Kids_U_Database_Reporting.Migrations
{
    public partial class RelationshipParent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentAptNumber2",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentEmailAddress2",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentNumber2",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelationshipParent2",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentAptNumber2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentEmailAddress2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentNumber2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RelationshipParent2",
                table: "Students");
        }
    }
}
