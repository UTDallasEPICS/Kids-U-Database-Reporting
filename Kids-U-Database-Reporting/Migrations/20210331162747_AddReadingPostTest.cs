using Microsoft.EntityFrameworkCore.Migrations;

namespace Kids_U_Database_Reporting.Migrations
{
    public partial class AddReadingPostTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReadingPostTest",
                table: "OutcomeMeasurements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadingPostTest",
                table: "OutcomeMeasurements");
        }
    }
}
