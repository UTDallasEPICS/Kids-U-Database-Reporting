﻿// <auto-generated />
using System;
using Kids_U_Database_Reporting.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kids_U_Database_Reporting.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210326192728_ParentName1")]
    partial class ParentName1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.District", b =>
                {
                    b.Property<int>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DistrictId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.OutcomeMeasurement", b =>
                {
                    b.Property<int>("OutcomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguagePostTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguagePreTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MathPostTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MathPreTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingFluencyTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingFluencyTest2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingFluencyTest3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingPreTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportSchoolGrade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportSchoolSemester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelfEsteemPostTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelfEsteemPreTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("OutcomeId");

                    b.HasIndex("StudentId");

                    b.ToTable("OutcomeMeasurements");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.ReportCard", b =>
                {
                    b.Property<int>("ReportCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageFifth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageFirst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageFourth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageSecond")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageSemester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageThird")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MathFifth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MathFirst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MathFourth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MathSecond")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MathSemester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MathThird")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingFifth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingFirst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingFourth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingSecond")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingSemester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingThird")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportSchoolGrade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportSchoolSemester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ReportCardId");

                    b.HasIndex("StudentId");

                    b.ToTable("ReportCards");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.Site", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("AgeAtEnrollment")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnrolledSemester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnrolledYear")
                        .HasColumnType("int");

                    b.Property<string>("Ethnicity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Income")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lunch")
                        .HasColumnType("bit");

                    b.Property<string>("ParentName1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolGrade")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnEnrolledSemester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnEnrolledYear")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.OutcomeMeasurement", b =>
                {
                    b.HasOne("Kids_U_Database_Reporting.Models.Student", "Student")
                        .WithMany("OutcomeMeasurements")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Kids_U_Database_Reporting.Models.ReportCard", b =>
                {
                    b.HasOne("Kids_U_Database_Reporting.Models.Student", "Student")
                        .WithMany("ReportCards")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
