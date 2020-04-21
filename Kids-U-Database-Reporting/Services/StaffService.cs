using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<ApplicationUser> GetStaffAsync(String Email)
        {
            return await _context.ApplicationUser
                .Where(x => x.Email == Email)
                .FirstAsync();
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
        public async Task<int> UpdateStaffAsync(ApplicationUser staff)
        {
            ApplicationUser editedStaff = await _context.ApplicationUser.FirstAsync(x => x.Email == staff.Email);
            if(editedStaff != null)
            {
                var oldRole = editedStaff.Role;
                editedStaff.Active = staff.Active;
                editedStaff.Role = staff.Role;
                editedStaff.Site = staff.Site;

    
                var result = await _userManager.UpdateAsync(editedStaff);
                if(result.Succeeded)
                {
                    if (oldRole != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(editedStaff, oldRole);
                    }


                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(editedStaff, editedStaff.Role);
                    }
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
