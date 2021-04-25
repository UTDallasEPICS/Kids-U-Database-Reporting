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
    public class OutcomeMeasurementController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISchoolService _schoolService;
        private readonly ISiteService _siteService;
        private readonly IReportCardService _reportCardService;
        private readonly IOutcomeMeasurementService _outcomeMeasurementService;
        private readonly ICommonService _commonService;

        public OutcomeMeasurementController(IStudentService studentService, ISchoolService schoolService, ISiteService siteService, IReportCardService reportCardService, IOutcomeMeasurementService outcomeMeasurementService, ICommonService commonService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
            _siteService = siteService;
            _reportCardService = reportCardService;
            _outcomeMeasurementService = outcomeMeasurementService;
            _commonService = commonService;
        }

        // Displays the latest report card for all students with filters from parameters
        public async Task<IActionResult> Index(Search searchData)
        {
            // Get all students who match the parameters with their report card data loaded
            var items = await _studentService.GetStudentsWithOutcomes(searchData, User.Identity.Name);
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

        // Displays all outcome measurements for one student
        public async Task<IActionResult> View(int studentId, string returnUrl) 
        {
            var student = await _studentService.GetStudent(studentId, User.Identity.Name);
            var model = new OutcomeViewModel()
            {
                OutcomeMeasurements = await _outcomeMeasurementService.GetOutcomes(studentId, User.Identity.Name),
                Student = student
            };

            ViewBag.returnUrl = returnUrl;

            if (student == null)
                return BadRequest("Could not access student");
            else
                return View(model);
        }

        public async Task<IActionResult> Add(int? studentId, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            ViewBag.StudentId = studentId; // Id used for default selected value of the student list
            ViewBag.StudentList = await _commonService.GetStudentNameList(User.Identity.Name); // List of students' full names and their Id
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View();
        }
        
        // Puts new outcome measurement in database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(OutcomeMeasurement newOutcomeMeasurement, string returnUrl)
        {
            var successful = await _outcomeMeasurementService.SubmitNewOutcome(newOutcomeMeasurement);

            if (!successful)
            {
                return BadRequest("Could not add outcome measurement.");
            }

            return RedirectToAction("View", "OutcomeMeasurement", new { newOutcomeMeasurement.Student.StudentId, returnUrl });
        }

        public async Task<IActionResult> Edit(int outcomeId, string returnUrl)
        {
            //goes to form to edit outcome measurement

            var model = await _outcomeMeasurementService.GetOutcome(outcomeId);

            ViewBag.returnUrl = returnUrl;
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View(model);
        }

        // Submit edit of Outcome Measurement to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OutcomeMeasurement editedOutcomeMeasurement, string returnUrl)
        {
            var successful = await _outcomeMeasurementService.ApplyEditOutcome(editedOutcomeMeasurement);

            if (!successful)
            {
                return BadRequest("Could not edit outcome measurement.");
            }

            editedOutcomeMeasurement = await _outcomeMeasurementService.GetOutcome(editedOutcomeMeasurement.OutcomeId);

            return RedirectToAction("View", "OutcomeMeasurement", new { editedOutcomeMeasurement.Student.StudentId, returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int outcomeId, int studentId, string returnUrl)
        {
            var successful = await _outcomeMeasurementService.DeleteOutcome(outcomeId);

            if (!successful)
            {
                return BadRequest("Could not delete Outcome Measurement.");
            }

            return RedirectToAction("View", "OutcomeMeasurement", new { studentId, returnUrl });
        }

        // Export a csv of Outcome Measurement data using current search filters
        public async Task<ActionResult> Export(Search searchData)
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _outcomeMeasurementService.GetAllOutcomes(searchData, User.Identity.Name));
            }
            return File(ms.ToArray(), "text/csv", $"OutcomeMeasurements_{DateTime.UtcNow.Date:d}.csv");
        }

        // Export a csv of a single student's Outcome Measurement data
        public async Task<ActionResult> ExportSingle(int studentId) 
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _outcomeMeasurementService.GetOutcomesWithStudent(studentId, User.Identity.Name));
            }
            return File(ms.ToArray(), "text/csv", $"OutcomeMeasurements_{DateTime.UtcNow.Date:d}.csv");
        }
    }
}