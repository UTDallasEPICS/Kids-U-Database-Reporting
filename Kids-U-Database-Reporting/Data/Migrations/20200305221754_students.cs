using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kids_U_Database_Reporting.Data.Migrations
{
    public partial class students : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First = table.Column<int>(nullable: true),
                    Second = table.Column<int>(nullable: true),
                    Third = table.Column<int>(nullable: true),
                    Fourth = table.Column<int>(nullable: true),
                    Fifth = table.Column<int>(nullable: true),
                    Semester = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradesId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    SchoolGrade = table.Column<string>(nullable: false),
                    Facility = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Income = table.Column<string>(nullable: true),
                    Ethnicity = table.Column<string>(nullable: true),
                    Enrolled = table.Column<int>(nullable: false),
                    UnEnrolled = table.Column<int>(nullable: true),
                    EnrolledSemester = table.Column<string>(nullable: true),
                    UnEnrolledSemester = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Lunch = table.Column<bool>(nullable: false),
                    SchoolName = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "ReportCards",
                columns: table => new
                {
                    ReportCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportSchoolGrade = table.Column<string>(nullable: false),
                    ReportSchoolSemester = table.Column<int>(nullable: false),
                    LanguageArtsGradesId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCards", x => x.ReportCardId);
                    table.ForeignKey(
                        name: "FK_ReportCards_Grades_LanguageArtsGradesId",
                        column: x => x.LanguageArtsGradesId,
                        principalTable: "Grades",
                        principalColumn: "GradesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportCards_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeMeasurements",
                columns: table => new
                {
                    OutcomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCardId = table.Column<int>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    MathPreTest = table.Column<int>(nullable: true),
                    MathPostTest = table.Column<int>(nullable: true),
                    LanguagePreTest = table.Column<int>(nullable: true),
                    LanguagePostTest = table.Column<int>(nullable: true),
                    ReadingPreTest = table.Column<int>(nullable: true),
                    ReadingFluencyTest = table.Column<int>(nullable: true),
                    ReadingFluencyTest2 = table.Column<int>(nullable: true),
                    ReadingFluencyTest3 = table.Column<int>(nullable: true),
                    SelfEsteemPreTest = table.Column<int>(nullable: true),
                    SelfEsteemPostTest = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeMeasurements", x => x.OutcomeId);
                    table.ForeignKey(
                        name: "FK_OutcomeMeasurements_ReportCards_ReportCardId",
                        column: x => x.ReportCardId,
                        principalTable: "ReportCards",
                        principalColumn: "ReportCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeMeasurements_ReportCardId",
                table: "OutcomeMeasurements",
                column: "ReportCardId",
                unique: true,
                filter: "[ReportCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCards_LanguageArtsGradesId",
                table: "ReportCards",
                column: "LanguageArtsGradesId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCards_StudentId",
                table: "ReportCards",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutcomeMeasurements");

            migrationBuilder.DropTable(
                name: "ReportCards");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
