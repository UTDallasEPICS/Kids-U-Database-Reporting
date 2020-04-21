using Kids_U_Database_Reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public interface ISiteService
    {
        Task<Site[]> GetSitesAsync();

        Task<Site> EditSiteAsync(int Id);

        Task<bool> DeleteSiteAsync(int Id);

        Task<bool> AddSiteAsync(Site newDistrict);

        Task<bool> ApplyEditSiteAsync(Site editedDistrict);
    }
}
