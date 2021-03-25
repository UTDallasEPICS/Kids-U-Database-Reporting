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
            var items = await _studentService.GetStudentsWithReportCards(searchData);
            searchData.ResultCount = items.Length;
            
            // Create model with the students and search data
            StudentViewModel model = new StudentViewModel()
            {
                Students = items,
                SearchData = searchData,
            };

            ViewBag.returnUrl = Url.Action() + Request.QueryString; // Get the current url with query string
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> Add(int? studentId, string returnUrl) // Create new report card for any student
        {
            // Create list for selecting student by full name
            var studentSelectList = new List<object>(); // Hold a list of anon objects. Select list needs key-value pairs for each option
            var studentList = await _studentService.GetStudents();
            foreach(var student in studentList)
                studentSelectList.Add(new {Id = student.StudentId, Name = student.FirstName+" "+student.LastName }); // Create anon object key and value for each select option
            ViewBag.StudentList = studentSelectList;

            ViewBag.returnUrl = returnUrl;
            ViewBag.StudentId = studentId; // Id used for default selected value of the student list
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View();
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> View(int Id, string returnUrl) // Displays all report cards for one student
        {
            var items = await _reportCardService.GetReportCards(Id);

            var model = new ReportCardViewModel()
            {
                ReportCards = items,
                Student = await _studentService.GetStudentById(Id)
            };

            ViewBag.returnUrl = returnUrl;

            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> Edit(int Id, string returnUrl) // Goes to form to edit report card
        {
            var model = await _reportCardService.GetReportCard(Id);

            ViewBag.returnUrl = returnUrl;
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View(model);
        }

        public async Task<IActionResult> ApplyEditReportCard(ReportCard editedReportCard, string returnUrl)
        {
            //submit edit of report card
            var successful = await _reportCardService.ApplyEditReportCard(editedReportCard);

            if (!successful)
                return BadRequest("Could not edit report card.");

            editedReportCard = await _reportCardService.GetReportCard(editedReportCard.ReportCardId);

            return RedirectToAction("View", "ReportCard", new { id = editedReportCard.Student.StudentId, returnUrl });
        }

        public async Task<IActionResult> SubmitNewReportCard(ReportCard newReportCard, string returnUrl)
        {
            //puts new reportCard in database
            var successful = await _reportCardService.SubmitNewReportCard(newReportCard);

            if (!successful)
                return BadRequest("Could not add report card.");

            return RedirectToAction("View", "ReportCard", new { id = newReportCard.Student.StudentId, returnUrl });
        }

        public async Task<ActionResult> Export(Search searchData) // Export a csv of report card data
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _reportCardService.GetAllReportCards(searchData));
            }
            return File(ms.ToArray(), "text/csv", $"ReportCards_{DateTime.UtcNow.Date:d}.csv");
        }

        public async Task<ActionResult> ExportSingle(int studentId) // Export a csv of a single student's report card data
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _reportCardService.GetReportCardsWithStudent(studentId));
            }
            return File(ms.ToArray(), "text/csv", $"ReportCards_{DateTime.UtcNow.Date:d}.csv");
        }
    }
}