using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StaffService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public async Task<ApplicationUser[]> GetAllStaffAsync()
        {
            return await _context.ApplicationUser
                .ToArrayAsync();
        }

        public async Task<ApplicationUser> GetStaffAsync(string Email)
        {
            return await _context.ApplicationUser
                .Where(x => x.Email == Email)
                .FirstAsync();
        }

        // Creates new user with given password. Returns false if failed
        public async Task<bool> AddNewStaff(ApplicationUser newStaff, string password)
        {
            var result = await _userManager.CreateAsync(newStaff, password); // Creates the user with password
            if (result.Succeeded) // Adds the user to the Global Admin role
            {
                await _userManager.AddToRoleAsync(newStaff, newStaff.Role);
            }
            return result.Succeeded;
        }

        public async Task<int> DeleteStaffAsync(string Email)
        {
            ApplicationUser deleteMe = await _context.ApplicationUser.FirstAsync(x => x.Email == Email);
             _context.ApplicationUser.Remove(deleteMe);
            int result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<UserRole[]> GetUserRolesAsync()
        {
            return await _context.UserRole
                .ToArrayAsync();
        }
        public async Task<int> UpdateStaffAsync(ApplicationUser staff, string oldEmail, string password)
        {
            ApplicationUser editedStaff = await _context.ApplicationUser.FirstAsync(x => x.Email == oldEmail); // Find user in database using un-edited email
            if(editedStaff != null)
            {
                var oldRole = editedStaff.Role;
                editedStaff.Active = staff.Active;
                editedStaff.Role = staff.Role;
                editedStaff.Site = staff.Site;
                editedStaff.UserName = staff.UserName;
                editedStaff.Email = staff.Email;
                editedStaff.FirstName = staff.FirstName;
                editedStaff.LastName = staff.LastName;

                var result = await _userManager.UpdateAsync(editedStaff);
               
                if(password != null)
                {
                    await _userManager.RemovePasswordAsync(editedStaff); // Remove password since changing requires current password
                    await _userManager.AddPasswordAsync(editedStaff, password); // Add new password
                }

                if (result.Succeeded)
                {
                    await _userManager.RemoveFromRoleAsync(editedStaff, oldRole); // Remove user from old role
                    await _userManager.AddToRoleAsync(editedStaff, editedStaff.Role); // Add user to new role

                    int success = await _context.SaveChangesAsync();
                    _context.Entry(editedStaff).State = EntityState.Modified;
                    return 1;
                }
                return -1;
            }
            return -1;
        }
    }
}
