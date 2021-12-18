using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kids_U_Database_Reporting.Migrations
{
    public partial class Initial : Migration
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
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(nullable: false),
                    ProgramNumber = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    SchoolName = table.Column<string>(nullable: false),
                    District = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    SiteName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteId);
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
                    EnrolledYear = table.Column<int>(nullable: true),
                    UnEnrolledYear = table.Column<int>(nullable: true),
                    EnrolledSemester = table.Column<string>(nullable: true),
                    UnEnrolledSemester = table.Column<string>(nullable: true),
                    AgeAtEnrollment = table.Column<int>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Lunch = table.Column<bool>(nullable: false),
                    SchoolName = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ParentName1 = table.Column<string>(nullable: true),
                    ParentNumber1 = table.Column<string>(nullable: true),
                    ParentEmailAddress1 = table.Column<string>(nullable: true),
                    RelationshipParent1 = table.Column<string>(nullable: true),
                    ParentAptNumber1 = table.Column<string>(nullable: true),
                    ParentName2 = table.Column<string>(nullable: true),
                    ParentNumber2 = table.Column<string>(nullable: true),
                    ParentEmailAddress2 = table.Column<string>(nullable: true),
                    RelationshipParent2 = table.Column<string>(nullable: true),
                    ParentAptNumber2 = table.Column<string>(nullable: true)
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
                name: "OutcomeMeasurements",
                columns: table => new
                {
                    OutcomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    ReportSchoolGrade = table.Column<string>(nullable: true),
                    ReportSchoolSemester = table.Column<string>(nullable: true),
                    MathPreTest = table.Column<string>(nullable: true),
                    MathPostTest = table.Column<string>(nullable: true),
                    LanguagePreTest = table.Column<string>(nullable: true),
                    LanguagePostTest = table.Column<string>(nullable: true),
                    ReadingPreTest = table.Column<string>(nullable: true),
                    ReadingPostTest = table.Column<string>(nullable: true),
                    ReadingFluencyTest = table.Column<string>(nullable: true),
                    ReadingFluencyTest2 = table.Column<string>(nullable: true),
                    ReadingFluencyTest3 = table.Column<string>(nullable: true),
                    SelfEsteemPreTest = table.Column<string>(nullable: true),
                    SelfEsteemPostTest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeMeasurements", x => x.OutcomeId);
                    table.ForeignKey(
                        name: "FK_OutcomeMeasurements_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportCards",
                columns: table => new
                {
                    ReportCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_OutcomeMeasurements_StudentId",
                table: "OutcomeMeasurements",
                column: "StudentId");

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
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "OutcomeMeasurements");

            migrationBuilder.DropTable(
                name: "ReportCards");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
