using Microsoft.EntityFrameworkCore.Migrations;

namespace Kids_U_Database_Reporting.Migrations
{
    public partial class StudentNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SchoolGrade",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "Lunch",
                table: "Students",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SchoolGrade",
                table: "Students",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Lunch",
                table: "Students",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
