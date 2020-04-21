
using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Configure
{
    public class SeedRoles
    {


        public static async Task Seed(ApplicationDbContext context, RoleManager<UserRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();
            //checks to see if the roles exsist and if they dont create them in db CreateIdentitySchema
            string role = "Global Administrator";
            string role1 = "Site Coordinator";
            string role2 = "Site Volunteer";
            string password = "EPICS2020";
            if ((await roleManager.FindByNameAsync(role)) == null)
            {
                await roleManager.CreateAsync(new UserRole(role));
            }
            if ((await roleManager.FindByNameAsync(role1)) == null)
            {
                await roleManager.CreateAsync(new UserRole(role1));
            }
            if ((await roleManager.FindByNameAsync(role2)) == null)
            {
                await roleManager.CreateAsync(new UserRole(role2));
            }

            if (await userManager.FindByNameAsync("UTD@TestAdmin") == null)
            {

                var user = new ApplicationUser
                {
                    UserName = "UTD@TestAdmin.com",
                    Email = "UTD@TestAdmin.com",
                    FirstName = "Code",
                    LastName = "Generator",
                    Site = "UTD",
                    Active = true,
                    Role = "Global Administrator",
                };
                //Creates the user and adds the password to it
                var result = await userManager.CreateAsync(user,password);
                //Adds the role to the user idenity 
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
           

            if (await userManager.FindByNameAsync("UTD@TestSite") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "UTD@TestSite.com",
                    Email = "UTD@TestSite.com",
                    FirstName = "Code",
                    LastName = "Editor",
                    Site = "UTD",
                    Active = true,
                    Role = "Site Administrator",
                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role1);
                }
            }

            if (await userManager.FindByNameAsync("UTD@TestVolunteer") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "UTD@TestVolunteer.com",
                    Email = "UTD@TestVolunteer.com",
                    FirstName = "Code",
                    LastName = "Fixer",
                    Site = "UTD",
                    Active = true,
                    Role = "Site Volunteer",
                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role2);
                }
            }





        }


    }
}
