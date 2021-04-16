using Kids_U_Database_Reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public interface IStaffService
    {

        Task<ApplicationUser[]> GetAllStaffAsync();
        Task<ApplicationUser> GetStaffAsync(string x);
        Task<UserRole[]> GetUserRolesAsync();
        Task<bool> AddNewStaff(ApplicationUser newStaff, string password);
        Task<int> UpdateStaffAsync(ApplicationUser x, string oldEmail, string password);

        Task<int> DeleteStaffAsync(string Email);
    }
}
