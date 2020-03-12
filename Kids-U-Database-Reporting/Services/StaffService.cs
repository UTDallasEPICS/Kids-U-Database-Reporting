using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
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

        public StaffService(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<UserRole[]> GetUserRolesAsync()
        {
            return await _context.UserRole
                .ToArrayAsync();
        }
    }
}
