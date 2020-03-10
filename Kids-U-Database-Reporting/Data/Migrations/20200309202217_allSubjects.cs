using Microsoft.EntityFrameworkCore.Migrations;

namespace Kids_U_Database_Reporting.Data.Migrations
{
    public partial class allSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportCards_Grades_LanguageArtsGradesId",
                table: "ReportCards");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_ReportCards_LanguageArtsGradesId",
                table: "ReportCards");

            migrationBuilder.DropColumn(
                name: "Enrolled",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UnEnrolled",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LanguageArtsGradesId",
                table: "ReportCards");

            migrationBuilder.AddColumn<int>(
                name: "EnrolledYear",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnEnrolledYear",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportSchoolSemester",
                table: "ReportCards",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "LanguageArts",
                columns: table => new
                {
                    LanguageArtsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCardId = table.Column<int>(nullable: true),
                    First = table.Column<int>(nullable: true),
                    Second = table.Column<int>(nullable: true),
                    Third = table.Column<int>(nullable: true),
                    Fourth = table.Column<int>(nullable: true),
                    Fifth = table.Column<int>(nullable: true),
                    Semester = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageArts", x => x.LanguageArtsId);
                    table.ForeignKey(
                        name: "FK_LanguageArts_ReportCards_ReportCardId",
                        column: x => x.ReportCardId,
                        principalTable: "ReportCards",
                        principalColumn: "ReportCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Math",
                columns: table => new
                {
                    MathId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCardId = table.Column<int>(nullable: true),
                    First = table.Column<int>(nullable: true),
                    Second = table.Column<int>(nullable: true),
                    Third = table.Column<int>(nullable: true),
                    Fourth = table.Column<int>(nullable: true),
                    Fifth = table.Column<int>(nullable: true),
                    Semester = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Math", x => x.MathId);
                    table.ForeignKey(
                        name: "FK_Math_ReportCards_ReportCardId",
                        column: x => x.ReportCardId,
                        principalTable: "ReportCards",
                        principalColumn: "ReportCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reading",
                columns: table => new
                {
                    ReadingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCardId = table.Column<int>(nullable: true),
                    First = table.Column<int>(nullable: true),
                    Second = table.Column<int>(nullable: true),
                    Third = table.Column<int>(nullable: true),
                    Fourth = table.Column<int>(nullable: true),
                    Fifth = table.Column<int>(nullable: true),
                    Semester = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading", x => x.ReadingId);
                    table.ForeignKey(
                        name: "FK_Reading_ReportCards_ReportCardId",
                        column: x => x.ReportCardId,
                        principalTable: "ReportCards",
                        principalColumn: "ReportCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageArts_ReportCardId",
                table: "LanguageArts",
                column: "ReportCardId",
                unique: true,
                filter: "[ReportCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Math_ReportCardId",
                table: "Math",
                column: "ReportCardId",
                unique: true,
                filter: "[ReportCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reading_ReportCardId",
                table: "Reading",
                column: "ReportCardId",
                unique: true,
                filter: "[ReportCardId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageArts");

            migrationBuilder.DropTable(
                name: "Math");

            migrationBuilder.DropTable(
                name: "Reading");

            migrationBuilder.DropColumn(
                name: "EnrolledYear",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UnEnrolledYear",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Enrolled",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnEnrolled",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportSchoolSemester",
                table: "ReportCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageArtsGradesId",
                table: "ReportCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fifth = table.Column<int>(type: "int", nullable: true),
                    First = table.Column<int>(type: "int", nullable: true),
                    Fourth = table.Column<int>(type: "int", nullable: true),
                    Second = table.Column<int>(type: "int", nullable: true),
                    Semester = table.Column<int>(type: "int", nullable: true),
                    Third = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportCards_LanguageArtsGradesId",
                table: "ReportCards",
                column: "LanguageArtsGradesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportCards_Grades_LanguageArtsGradesId",
                table: "ReportCards",
                column: "LanguageArtsGradesId",
                principalTable: "Grades",
                principalColumn: "GradesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
