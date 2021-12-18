using Microsoft.EntityFrameworkCore.Migrations;

namespace Kids_U_Database_Reporting.Migrations
{
    public partial class OrgAdditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProgramNumber",
                table: "Organizations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail1",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail2",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName1",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName2",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone1",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone2",
                table: "Organizations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ContactEmail1",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ContactEmail2",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ContactName1",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ContactName2",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ContactPhone1",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ContactPhone2",
                table: "Organizations");

            migrationBuilder.AlterColumn<string>(
                name: "ProgramNumber",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
