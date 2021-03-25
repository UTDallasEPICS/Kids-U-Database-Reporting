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
        private readonly ICommonService _commonService;

        public OutcomeMeasurementController(IStudentService studentService, ISchoolService schoolService, ISiteService siteService, IReportCardService reportCardService, ICommonService commonService)
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
            var items = await _studentService.GetStudentsWithOutcomeMeasurements(searchData);
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

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> View(int Id, string returnUrl)
        {
            //displays all outcome measurements for one student

            var items = await _studentService.GetOutcomes(Id);

            var model = new OutcomeViewModel()
            {
                OutcomeMeasurements = items,
                Student = await _studentService.GetStudentById(Id)
            };

            ViewBag.returnUrl = returnUrl;

            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> Add(int? studentId, string returnUrl)
        {
            // Create list for selecting student by full name
            var studentSelectList = new List<object>(); // Hold a list of anon objects. Select list needs key-value pairs for each option
            var studentList = await _studentService.GetStudents();
            foreach (var student in studentList)
                studentSelectList.Add(new { Id = student.StudentId, Name = student.FirstName + " " + student.LastName }); // Create anon object key and value for each select option
            ViewBag.StudentList = studentSelectList;

            ViewBag.returnUrl = returnUrl;
            ViewBag.StudentId = studentId; // Id used for default selected value of the student list
            Console.WriteLine("Add id " + studentId);
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };


            return View();
        }
        
        public async Task<IActionResult> SubmitNewOutcome(OutcomeMeasurement newOutcomeMeasurement, string returnUrl)
        {
            //puts new outcome measurement in database

            var successful = await _studentService.SubmitNewOutcome(newOutcomeMeasurement);

            if (!successful)
            {
                return BadRequest("Could not add outcome measurement.");
            }

            return RedirectToAction("View", "OutcomeMeasurement", new { id = newOutcomeMeasurement.Student.StudentId, returnUrl });
        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> Edit(int Id, string returnUrl)
        {
            //goes to form to edit outcome measurement

            var model = await _studentService.GetOutcome(Id);

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
            var successful = await _studentService.ApplyEditOutcome(editedOutcomeMeasurement);

            if (!successful)
            {
                return BadRequest("Could not edit outcome measurement.");
            }

            editedOutcomeMeasurement = await _studentService.GetOutcome(editedOutcomeMeasurement.OutcomeId);

            return RedirectToAction("View", "OutcomeMeasurement", new { id = editedOutcomeMeasurement.Student.StudentId, returnUrl });
        }
    }
}