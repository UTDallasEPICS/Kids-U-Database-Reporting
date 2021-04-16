
using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Configure
{
    public class SeedRoles
    {
        public static async Task Seed(ApplicationDbContext context, RoleManager<UserRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();
            // Checks to see if the roles exists and if they dont create them in db CreateIdentitySchema
            string globalAdminRole = "Global Administrator";
            string siteCoordinatorRole = "Site Coordinator";
            string siteVolunteerRole = "Site Volunteer";

            if ((await roleManager.FindByNameAsync(globalAdminRole)) == null)
            {
                await roleManager.CreateAsync(new UserRole(globalAdminRole));
            }
            if ((await roleManager.FindByNameAsync(siteCoordinatorRole)) == null)
            {
                await roleManager.CreateAsync(new UserRole(siteCoordinatorRole));
            }
            if ((await roleManager.FindByNameAsync(siteVolunteerRole)) == null)
            {
                await roleManager.CreateAsync(new UserRole(siteVolunteerRole));
            }
            
            string password = "EPICS2021"; // Password used for creating default account
            if (await userManager.FindByNameAsync("Admin") == null) // Create the default Admin account
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@email.com",
                    FirstName = "Site",
                    LastName = "Admin",
                    Site = "",
                    Active = true,
                    Role = "Global Administrator",
                };

                var result = await userManager.CreateAsync(user, password); // Creates the user and adds the default password to it

                if (result.Succeeded) // Adds the user to the Global Admin role
                {
                    await userManager.AddToRoleAsync(user, globalAdminRole);
                }
            }
        }
    }
}
