using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kids_U_Database_Reporting.Services;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Authorization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Kids_U_Database_Reporting.Controllers
{
    public class ReportCardController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISchoolService _schoolService;
        private readonly ISiteService _siteService;
        
        public ReportCardController(IStudentService studentService, ISchoolService schoolService, ISiteService siteService)
        {
            //constructor

            _studentService = studentService;
            _schoolService = schoolService;
            _siteService = siteService;
        }

        // Displays the latest report card for all students with filters from parameters
        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> Index(Search searchData)
        {
            // Get all students who match the parameters with their report card data loaded
            var items = await _studentService.GetStudentsWithReportCardsAsync(searchData);

            searchData.ResultCount = items.Length;
            searchData.SchoolList = await GetSchoolSelectList();
            searchData.SiteList = await GetSiteSelectList();

            // Create model with the students and search data
            StudentViewModel model = new StudentViewModel()
            {
                Students = items,
                SearchData = searchData
            };
            
            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> Add() // Create new report card for any student
        {
            // Create list for making student select element, use custom object to show a full name
            var studentList = await _studentService.GetStudentsAsync();
            var studentSelectList = new List<object>(); // List of anon objects, select list needs key-value pair for data
            foreach(var student in studentList)
                studentSelectList.Add(new {Id = student.StudentId, Name = student.FirstName+" "+student.LastName }); // Create anon object with the Id and Name
            ViewBag.StudentList = studentSelectList;

            return View();
        }
        public async Task<ActionResult> ExportStudents(Search searchData) // Export a csv of student data https://stackoverflow.com/a/62125940
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _studentService.GetStudentsAsync(searchData));
            }
            return File(ms.ToArray(), "text/csv", $"StudentData_{DateTime.UtcNow.Date.ToString("d")}.csv");
        }


        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> ReportCardIndex(int Id)
        {
            //displays all report cards for one student
            var items = await _studentService.GetReportCardsAsync(Id);

            var model = new ReportCardViewModel()
            {
                ReportCards = items,
                Student = await _studentService.GetStudentById(Id)
            };
            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> CreateReportCard(int Id)
        {
            //goes to form to create report card

            Student student = await _studentService.EditStudentAsync(Id);

            ViewBag.FirstName = student.FirstName;
            ViewBag.LastName = student.LastName;
            ViewBag.Student = student;

            return View();
        }
        
        public async Task<IActionResult> SubmitNewReportCard(ReportCard newReportCard)
        {
            //puts new reportCard in database
            var successful = await _studentService.SubmitNewReportCardAsync(newReportCard);

            if (!successful)
                return BadRequest("Could not add report card.");

            return RedirectToAction("ReportCardIndex", "ReportCard", new { id = newReportCard.Student.StudentId });
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> EditReportCard(int Id)
        {
            //goes to form to edit report card
            var model = await _studentService.GetReportCardAsync(Id);

            return View(model);
        }

        public async Task<IActionResult> ApplyEditReportCard(ReportCard editedReportCard)
        {
            //submit edit of report card
            var successful = await _studentService.ApplyEditReportCardAsync(editedReportCard);

            if (!successful)
                return BadRequest("Could not edit report card.");

            editedReportCard = await _studentService.GetReportCardAsync(editedReportCard.ReportCardId);

            return RedirectToAction("ReportCardIndex", "Student", new { id = editedReportCard.Student.StudentId });
        }

        public async Task<List<String>> GetSiteSelectList() // Get current sites from database for html select element, default value is Select KU Site
        {
            List<String> siteList = new List<string> { "Select KU Site" }; 
            var sites = await _siteService.GetSitesAsync();
            foreach (Site site in sites)
                siteList.Add(site.SiteName);
            return siteList;
        }

        public async Task<List<String>> GetSchoolSelectList() // Get current schools from database for html select element, default value is Select School
        {
            List<String> schoolList = new List<string> { "Select School" };
            var schools = await _schoolService.GetSchoolsAsync();
            foreach (School school in schools)
                schoolList.Add(school.SchoolName);
            return schoolList;
        }
    }
}