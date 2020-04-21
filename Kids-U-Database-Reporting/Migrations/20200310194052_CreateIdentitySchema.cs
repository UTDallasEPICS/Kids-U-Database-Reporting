using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kids_U_Database_Reporting.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
<<<<<<< HEAD:Kids-U-Database-Reporting/Migrations/20200328234409_first.cs
=======
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
>>>>>>> login:Kids-U-Database-Reporting/Migrations/20200310194052_CreateIdentitySchema.cs
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
<<<<<<< HEAD:Kids-U-Database-Reporting/Migrations/20200328234409_first.cs
                    EnrolledYear = table.Column<int>(nullable: true),
                    UnEnrolledYear = table.Column<int>(nullable: true),
                    EnrolledSemester = table.Column<string>(nullable: true),
                    UnEnrolledSemester = table.Column<string>(nullable: true),
                    AgeAtEnrollment = table.Column<int>(nullable: true),
=======
                    Enrolled = table.Column<int>(nullable: false),
                    UnEnrolled = table.Column<int>(nullable: true),
>>>>>>> login:Kids-U-Database-Reporting/Migrations/20200310194052_CreateIdentitySchema.cs
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
<<<<<<< HEAD:Kids-U-Database-Reporting/Migrations/20200328234409_first.cs
                name: "OutcomeMeasurements",
                columns: table => new
                {
                    OutcomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: true),
                    ReportSchoolGrade = table.Column<string>(nullable: true),
                    ReportSchoolSemester = table.Column<string>(nullable: true),
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
                        name: "FK_OutcomeMeasurements_Students_StudentId",
=======
                name: "ReportCards",
                columns: table => new
                {
                    ReportCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportSchoolGrade = table.Column<int>(nullable: false),
                    ReportSchoolSemester = table.Column<string>(nullable: true),
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
>>>>>>> login:Kids-U-Database-Reporting/Migrations/20200310194052_CreateIdentitySchema.cs
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
<<<<<<< HEAD:Kids-U-Database-Reporting/Migrations/20200328234409_first.cs
                name: "ReportCards",
                columns: table => new
                {
                    ReportCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: true),
                    ReportSchoolGrade = table.Column<string>(nullable: true),
                    ReportSchoolSemester = table.Column<string>(nullable: true),
                    MathFirst = table.Column<string>(nullable: true),
                    MathSecond = table.Column<string>(nullable: true),
                    MathThird = table.Column<string>(nullable: true),
                    MathFourth = table.Column<string>(nullable: true),
                    MathFifth = table.Column<string>(nullable: true),
                    MathSemester = table.Column<string>(nullable: true),
                    ReadingFirst = table.Column<string>(nullable: true),
                    ReadingSecond = table.Column<string>(nullable: true),
                    ReadingThird = table.Column<string>(nullable: true),
                    ReadingFourth = table.Column<string>(nullable: true),
                    ReadingFifth = table.Column<string>(nullable: true),
                    ReadingSemester = table.Column<string>(nullable: true),
                    LanguageFirst = table.Column<string>(nullable: true),
                    LanguageSecond = table.Column<string>(nullable: true),
                    LanguageThird = table.Column<string>(nullable: true),
                    LanguageFourth = table.Column<string>(nullable: true),
                    LanguageFifth = table.Column<string>(nullable: true),
                    LanguageSemester = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCards", x => x.ReportCardId);
                    table.ForeignKey(
                        name: "FK_ReportCards_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
=======
                name: "OutcomeMeasurements",
                columns: table => new
                {
                    OutcometId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_OutcomeMeasurements", x => x.OutcometId);
                    table.ForeignKey(
                        name: "FK_OutcomeMeasurements_ReportCards_ReportCardId",
                        column: x => x.ReportCardId,
                        principalTable: "ReportCards",
                        principalColumn: "ReportCardId",
>>>>>>> login:Kids-U-Database-Reporting/Migrations/20200310194052_CreateIdentitySchema.cs
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
<<<<<<< HEAD:Kids-U-Database-Reporting/Migrations/20200328234409_first.cs
                name: "IX_OutcomeMeasurements_StudentId",
                table: "OutcomeMeasurements",
                column: "StudentId");
=======
                name: "IX_OutcomeMeasurements_ReportCardId",
                table: "OutcomeMeasurements",
                column: "ReportCardId",
                unique: true,
                filter: "[ReportCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCards_LanguageArtsGradesId",
                table: "ReportCards",
                column: "LanguageArtsGradesId");
>>>>>>> login:Kids-U-Database-Reporting/Migrations/20200310194052_CreateIdentitySchema.cs

            migrationBuilder.CreateIndex(
                name: "IX_ReportCards_StudentId",
                table: "ReportCards",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OutcomeMeasurements");

            migrationBuilder.DropTable(
<<<<<<< HEAD:Kids-U-Database-Reporting/Migrations/20200328234409_first.cs
                name: "ReportCards");

            migrationBuilder.DropTable(
=======
>>>>>>> login:Kids-U-Database-Reporting/Migrations/20200310194052_CreateIdentitySchema.cs
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
<<<<<<< HEAD:Kids-U-Database-Reporting/Migrations/20200328234409_first.cs
=======
                name: "ReportCards");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
>>>>>>> login:Kids-U-Database-Reporting/Migrations/20200310194052_CreateIdentitySchema.cs
                name: "Students");
        }
    }
}
