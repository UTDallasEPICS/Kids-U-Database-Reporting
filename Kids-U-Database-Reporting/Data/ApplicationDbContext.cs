using System;
using System.Collections.Generic;
using System.Text;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kids_U_Database_Reporting.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //add DbSet property (table/collection in database) refers to model class of same name for columns
        //MUST sync to database after editing with:
        //tools -> nuget package manager -> console
        //add-migration exampleName
        //Update-Database

        //Students is name of table that matches the Student class
        public DbSet<Student> Students { get; set; }
        public DbSet<OutcomeMeasurement> OutcomeMeasurements { get; set; }
        public DbSet<ReportCard> ReportCards { get; set; }
        public DbSet<School> Schools { get; set; }
        
        public DbSet<District> Districts { get; set; }
        
        public DbSet<Site> Sites { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<ApplicationUser> ApplicationUser{get; set;}

        public DbSet<UserRole> UserRole {get; set;}

        //uncomment these when created:
        //public DbSet<School> Schools { get; set; }
        //public DbSet<District> Districts { get; set; }


    }
}
