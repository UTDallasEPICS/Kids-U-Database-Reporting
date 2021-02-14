using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public class CommonService : ICommonService // Defines commonly used methods
    {
        private readonly IStudentService _studentService;
        private readonly ISchoolService _schoolService;
        private readonly ISiteService _siteService;

        public CommonService(IStudentService studentService, ISchoolService schoolService, ISiteService siteService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
            _siteService = siteService;
        }

        public async Task<List<SelectListItem>> GetSiteSelectList() // Get current sites from database for html select element, default value is Select KU Site
        {
            List<SelectListItem> siteList = new List<SelectListItem> { new SelectListItem { Text = "Select KU Site" } };
            var sites = await _siteService.GetSitesAsync();
            foreach (Site site in sites)
                siteList.Add(new SelectListItem { Text = site.SiteName });
            return siteList;
        }

        public async Task<List<SelectListItem>> GetSchoolSelectList() // Get current schools from database for html select element, default value is Select School
        {
            List<SelectListItem> schoolList = new List<SelectListItem> { new SelectListItem { Text =  "Select School" } };
            var schools = await _schoolService.GetSchoolsAsync();
            foreach (School school in schools)
                schoolList.Add(new SelectListItem { Text = school.SchoolName });
            return schoolList;
        }
    }
}
