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

        // Create list of objects with the StudentId and their full name for every student
        public async Task<List<object>> GetStudentNameList(string userName)
        {
            var studentSelectList = new List<object>() { new { Id = -1, Name = "Select Student" } }; // Create list to hold anonymous objects. First element is Select Student
            var studentList = await _studentService.GetStudents(new Search(), userName); // Get only active students with empty Search. Default value is to ignore inactive students
            foreach (var student in studentList) // Make an anon object for every student. Id is the key and Name is the value used to create a select list with html
                studentSelectList.Add(new { Id = student.StudentId, Name = student.FirstName + " " + student.LastName });
            return studentSelectList;
        }

        // Get current sites from database for html select element, default value is Select KU Site
        public async Task<List<SelectListItem>> GetSiteSelectList() 
        {
            List<SelectListItem> siteList = new List<SelectListItem> { new SelectListItem { Value = "", Text = "Select KU Site" } };
            var sites = await _siteService.GetSitesAsync();
            foreach (Site site in sites)
                siteList.Add(new SelectListItem { Text = site.SiteName });
            return siteList;
        }

        // Get current schools from database for html select element, default value is Select School
        public async Task<List<SelectListItem>> GetSchoolSelectList() 
        {
            List<SelectListItem> schoolList = new List<SelectListItem> { new SelectListItem { Value="", Text =  "Select School" } };
            var schools = await _schoolService.GetSchoolsAsync();
            foreach (School school in schools)
                schoolList.Add(new SelectListItem { Text = school.SchoolName });
            return schoolList;
        }
    }
}
