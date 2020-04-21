using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly ApplicationDbContext _context;


        public DistrictService(ApplicationDbContext context)
        {
            //new instance of service is made during each request (required for talking to database) aka scoped lifecycle
            _context = context;
        }
        public async Task<District[]> GetDistrictsAsync()
        {
            return await _context.Districts
              .ToArrayAsync();
        }

        public async Task<District> EditDistrictAsync(int Id)
        {
            return await _context.Districts.Where(x => x.DistrictId == Id).FirstAsync();
        }

        public async Task<bool> DeleteDistrictAsync(int Id)
        {
            District deleteDistrict = await _context.Districts.Where(x => x.DistrictId == Id).FirstAsync();
            _context.Districts.Remove(deleteDistrict);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> AddDistrictAsync(District newDistrict)
        {
            _context.Districts.Add(newDistrict);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> ApplyEditDistrictAsync(District editedDistrict)
        {
            _context.Entry(await _context.Districts.FirstAsync(x => x.DistrictId == editedDistrict.DistrictId)).CurrentValues.SetValues(editedDistrict);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
