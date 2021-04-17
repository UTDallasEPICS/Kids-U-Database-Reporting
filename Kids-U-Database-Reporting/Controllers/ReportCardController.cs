using System;
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
    [Authorize(Roles = "Global Administrator, Site Coordinator")]
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
        public async Task<IActionResult> Index(Search searchData)
        {
            // Get all students who match the parameters with their report card data loaded
            var items = await _studentService.GetStudentsWithReportCards(searchData, User.Identity.Name);
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

        // Create new Report Card for any student
        public async Task<IActionResult> Add(int? studentId, string returnUrl) 
        {
            ViewBag.returnUrl = returnUrl;
            ViewBag.StudentId = studentId; // Id used for default selected value of the student list
            ViewBag.StudentList = await _commonService.GetStudentNameList(); // List of students' full names and their Id
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View();
        }

        // Displays all report cards for one student
        public async Task<IActionResult> View(int Id, string returnUrl) 
        {
            var student = await _studentService.GetStudent(Id, User.Identity.Name);
            var model = new ReportCardViewModel()
            {
                ReportCards = await _reportCardService.GetReportCards(Id, User.Identity.Name),
                Student = student
            };

            ViewBag.returnUrl = returnUrl;

            if (student == null)
                return BadRequest("Could not access student");
            else
                return View(model);
        }

        // Goes to form to edit report card
        public async Task<IActionResult> Edit(int Id, string returnUrl) 
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

            return RedirectToAction("View", "ReportCard", new { Id = editedReportCard.Student.StudentId, returnUrl });
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int reportId, int studentId, string returnUrl)
        {
            var successful = await _reportCardService.DeleteReport(reportId);

            if (!successful)
            {
                return BadRequest("Could not delete Report Card.");
            }

            return RedirectToAction("View", "ReportCard", new { Id = studentId, returnUrl });
        }

        // Puts new ReportCard in database
        public async Task<IActionResult> SubmitNewReportCard(ReportCard newReportCard, string returnUrl)
        {
            var successful = await _reportCardService.SubmitNewReportCard(newReportCard);

            if (!successful)
                return BadRequest("Could not add report card.");

            return RedirectToAction("View", "ReportCard", new { Id = newReportCard.Student.StudentId, returnUrl });
        }

        // Export a csv of Report Card data using current search filters
        public async Task<ActionResult> Export(Search searchData) 
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _reportCardService.GetAllReportCards(searchData, User.Identity.Name));
            }
            
            return File(ms.ToArray(), "text/csv", $"ReportCards_{DateTime.UtcNow.Date:d}.csv");
        }

        // Export a csv of a single student's Report Card data
        public async Task<ActionResult> ExportSingle(int studentId) 
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _reportCardService.GetReportCardsWithStudent(studentId, User.Identity.Name));
            }
            return File(ms.ToArray(), "text/csv", $"ReportCards_{DateTime.UtcNow.Date:d}.csv");
        }
    }
}