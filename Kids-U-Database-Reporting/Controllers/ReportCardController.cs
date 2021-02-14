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
        private readonly IReportCardService _reportCardService;
        private readonly ICommonService _commonService;
        
        public ReportCardController(IStudentService studentService, ISchoolService schoolService, ISiteService siteService, IReportCardService reportCardService, ICommonService commonService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
            _siteService = siteService;
            _reportCardService = reportCardService;
            _commonService = commonService;
        }

        // Displays the latest report card for all students with filters from parameters
        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> Index(Search searchData)
        {
            // Get all students who match the parameters with their report card data loaded
            var items = await _studentService.GetStudentsWithReportCardsAsync(searchData);

            searchData.ResultCount = items.Length;
            searchData.SchoolList = await _commonService.GetSchoolSelectList();
            searchData.SiteList = await _commonService.GetSiteSelectList();

            // Create model with the students and search data
            StudentViewModel model = new StudentViewModel()
            {
                Students = items,
                SearchData = searchData
            };
            
            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> Add(int studentId) // Create new report card for any student
        {
            ViewBag.StudentId = studentId;

            // Create list for making student select element, use custom object to show a full name
            var studentList = await _studentService.GetStudentsAsync();
            var studentSelectList = new List<object>(); // List of anon objects, select list needs key-value pair for data
            foreach(var student in studentList)
                studentSelectList.Add(new {Id = student.StudentId, Name = student.FirstName+" "+student.LastName }); // Create anon object with the Id for key and Name for value
            ViewBag.StudentList = studentSelectList;

            return View();
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> View(int Id)
        {
            //displays all report cards for one student
            var items = await _reportCardService.GetStudentReportCardsAsync(Id);

            var model = new ReportCardViewModel()
            {
                ReportCards = items,
                Student = await _studentService.GetStudentById(Id)
            };
            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> Edit(int Id)
        {
            //goes to form to edit report card
            var model = await _reportCardService.GetReportCardAsync(Id);

            return View(model);
        }

        public async Task<IActionResult> ApplyEditReportCard(ReportCard editedReportCard)
        {
            //submit edit of report card
            var successful = await _reportCardService.ApplyEditReportCardAsync(editedReportCard);

            if (!successful)
                return BadRequest("Could not edit report card.");

            editedReportCard = await _reportCardService.GetReportCardAsync(editedReportCard.ReportCardId);

            return RedirectToAction("ReportCardIndex", "Student", new { id = editedReportCard.Student.StudentId });
        }
        public async Task<ActionResult> Export(Search searchData) // Export a csv of report card data
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _reportCardService.GetAllReportCardsAsync(searchData));
            }
            return File(ms.ToArray(), "text/csv", $"ReportCards_{DateTime.UtcNow.Date:d}.csv");
        }
        public async Task<ActionResult> ExportStudent(int studentId) // Export a csv of a single student's report card data
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _reportCardService.GetStudentReportCardsWithStudentAsync(studentId));
            }
            return File(ms.ToArray(), "text/csv", $"ReportCards_{DateTime.UtcNow.Date:d}.csv");
        }
    }
}