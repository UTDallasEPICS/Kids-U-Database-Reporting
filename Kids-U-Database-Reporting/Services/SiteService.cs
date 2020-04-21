using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class SiteService : ISiteService
    {
        private readonly ApplicationDbContext _context;


        public SiteService(ApplicationDbContext context)
        {
            //new instance of service is made during each request (required for talking to database) aka scoped lifecycle
            _context = context;
        }
        public async Task<Site[]> GetSitesAsync()
        {
            return await _context.Sites
              .ToArrayAsync();
        }

        public async Task<Site> EditSiteAsync(int Id)
        {
            return await _context.Sites.Where(x => x.SiteId == Id).FirstAsync();
        }

        public async Task<bool> DeleteSiteAsync(int Id)
        {
            Site deleteSite = await _context.Sites.Where(x => x.SiteId == Id).FirstAsync();
            _context.Sites.Remove(deleteSite);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> AddSiteAsync(Site newSite)
        {
            _context.Sites.Add(newSite);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> ApplyEditSiteAsync(Site editedSite)
        {
            _context.Entry(await _context.Sites.FirstAsync(x => x.SiteId == editedSite.SiteId)).CurrentValues.SetValues(editedSite);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}

