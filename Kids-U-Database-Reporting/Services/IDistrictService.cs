using Kids_U_Database_Reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public interface IDistrictService
    {
        Task<District[]> GetDistrictsAsync();

        Task<District> EditDistrictAsync(int Id);

        Task<bool> DeleteDistrictAsync(int Id);

        Task<bool> AddDistrictAsync(District newDistrict);

        Task<bool> ApplyEditDistrictAsync(District editedDistrict);
    }
}
