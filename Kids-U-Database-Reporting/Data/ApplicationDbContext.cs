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

        //add DbSet property (table/collection in database) refers to model class for attributes
        //MUST sync to database after editing with:
        //add-migration exampleName
        //Update-Database

        //Students is name of table that matches the Student class
        public DbSet<Student> Students { get; set; }

    }
}
