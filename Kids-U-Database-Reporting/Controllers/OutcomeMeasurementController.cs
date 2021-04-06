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
        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> Index(Search searchData)
        {
            // Get all students who match the parameters with their report card data loaded
            var items = await _studentService.GetStudentsWithOutcomes(searchData);
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
        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> View(int Id, string returnUrl) 
        {
            var model = new OutcomeViewModel()
            {
                OutcomeMeasurements = await _outcomeMeasurementService.GetOutcomes(Id),
                Student = await _studentService.GetStudent(Id)
            };

            ViewBag.returnUrl = returnUrl;

            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
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
        
        // Puts new outcome measurement in database
        public async Task<IActionResult> SubmitNewOutcome(OutcomeMeasurement newOutcomeMeasurement, string returnUrl)
        {

            var successful = await _outcomeMeasurementService.SubmitNewOutcome(newOutcomeMeasurement);

            if (!successful)
            {
                return BadRequest("Could not add outcome measurement.");
            }

            return RedirectToAction("View", "OutcomeMeasurement", new { id = newOutcomeMeasurement.Student.StudentId, returnUrl });
        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int outcomeId, int studentId, string returnUrl)
        {
            var successful = await _outcomeMeasurementService.DeleteOutcome(outcomeId);

            if (!successful)
            {
                return BadRequest("Could not delete Outcome Measurement.");
            }

            return RedirectToAction("View", "OutcomeMeasurement", new { id = studentId, returnUrl });
        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> Edit(int Id, string returnUrl)
        {
            //goes to form to edit outcome measurement

            var model = await _outcomeMeasurementService.GetOutcome(Id);

            ViewBag.returnUrl = returnUrl;
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View(model);
        }

        public async Task<IActionResult> ApplyEditOutcome(OutcomeMeasurement editedOutcomeMeasurement, string returnUrl)
        {
            //submit edit of report card
            var successful = await _outcomeMeasurementService.ApplyEditOutcome(editedOutcomeMeasurement);

            if (!successful)
            {
                return BadRequest("Could not edit outcome measurement.");
            }

            editedOutcomeMeasurement = await _outcomeMeasurementService.GetOutcome(editedOutcomeMeasurement.OutcomeId);

            return RedirectToAction("View", "OutcomeMeasurement", new { id = editedOutcomeMeasurement.Student.StudentId, returnUrl });
        }

        // Export a csv of Outcome Measurement data using current search filters
        public async Task<ActionResult> Export(Search searchData)
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _outcomeMeasurementService.GetAllOutcomes(searchData));
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
                cw.WriteRecords(await _outcomeMeasurementService.GetOutcomesWithStudent(studentId));
            }
            return File(ms.ToArray(), "text/csv", $"OutcomeMeasurements_{DateTime.UtcNow.Date:d}.csv");
        }
    }
}