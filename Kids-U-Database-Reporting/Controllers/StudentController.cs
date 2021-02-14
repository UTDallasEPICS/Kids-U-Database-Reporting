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
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISchoolService _schoolService;
        private readonly ISiteService _siteService;
        private readonly IReportCardService _reportCardService;
        private readonly ICommonService _commonService;

        public StudentController(IStudentService studentService, ISchoolService schoolService, ISiteService siteService, IReportCardService reportCardService, ICommonService commonService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
            _siteService = siteService;
            _reportCardService = reportCardService;
            _commonService = commonService;
        }

        // Displays all students with filters from parameters
        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> Index(Search searchData)
        {
            // Get all students who match the parameters
            var items = await _studentService.GetStudentsAsync(searchData);

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
        public async Task<IActionResult> AddAsync()
        {
            //goes to form to create student

            ViewBag.SchoolList = await _commonService.GetSchoolSelectList();
            ViewBag.SiteList = await _commonService.GetSiteSelectList();

            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student newStudent)
        {
            //puts new student in database

            var successful = await _studentService.AddStudentAsync(newStudent);

            if (!successful)
            {
                return BadRequest("Could not add student.");
            }

            return RedirectToAction("Index", "Student");
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> Delete(int Id)
        {
            //deletes student from database

            var successful = await _studentService.DeleteStudentAsync(Id);

            if (!successful)
            {
                return BadRequest("Could not delete Student.");
            }

            return RedirectToAction("Index", "Student");
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> View(int Id)
        {
            return View(await _studentService.GetStudentById(Id));
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> Edit(int Id)
        {
            //goes to form to edit student

            var model = await _studentService.GetStudentById(Id);

            ViewBag.SchoolList = await _commonService.GetSchoolSelectList();
            ViewBag.SiteList = await _commonService.GetSiteSelectList();

            return View(model);
        }

        public async Task<IActionResult> ApplyEdit(Student editedStudent)
        {
            //submit edits of student

            var successful = await _studentService.ApplyEditStudentAsync(editedStudent);

            if (!successful)
            {
                return BadRequest("Could not edit student.");
            }
            
            return RedirectToAction("Index", "Student");

        }

        public async Task<ActionResult> Export(Search searchData) // Export a csv of student data https://stackoverflow.com/a/62125940
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _studentService.GetStudentsAsync(searchData));
            }
            return File(ms.ToArray(), "text/csv", $"StudentData_{DateTime.UtcNow.Date:d}.csv");
        }





        //REPORT CARD STUFF STARTS HERE
        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> ReportCardIndex(int Id)
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
            var successful = await _reportCardService.SubmitNewReportCardAsync(newReportCard);

            if (!successful)
                return BadRequest("Could not add report card.");

            return RedirectToAction("ReportCardIndex", "Student", new { id = newReportCard.Student.StudentId });
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> EditReportCard(int Id)
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




        //OUTCOME MEASUREMENTS STUFF STARTS HERE
        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> OutcomeIndex(int Id)
        {
            //displays all outcome measurements for one student

            var items = await _studentService.GetOutcomesAsync(Id);

            var model = new OutcomeViewModel()
            {
                OutcomeMeasurements = items,
                Student = await _studentService.GetStudentById(Id)
            };

            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> CreateOutcome(int Id)
        {
            //goes to form to create outcome measurement

            Student student = await _studentService.GetStudentById(Id);

            ViewBag.FirstName = student.FirstName;
            ViewBag.LastName = student.LastName;
            ViewBag.Student = student;

            return View();
        }
        
        public async Task<IActionResult> SubmitNewOutcome(OutcomeMeasurement newOutcomeMeasurement)
        {
            //puts new outcome measurement in database

            var successful = await _studentService.SubmitNewOutcomeAsync(newOutcomeMeasurement);

            if (!successful)
            {
                return BadRequest("Could not add outcome measurement.");
            }

            return RedirectToAction("OutcomeIndex", "Student", new { id = newOutcomeMeasurement.Student.StudentId });


        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> EditOutcome(int Id)
        {
            //goes to form to edit outcome measurement

            var model = await _studentService.GetOutcomeAsync(Id);

            return View(model);
        }

        public async Task<IActionResult> ApplyEditOutcome(OutcomeMeasurement editedOutcomeMeasurement)
        {
            //submit edit of report card
            var successful = await _studentService.ApplyEditOutcomeAsync(editedOutcomeMeasurement);

            if (!successful)
            {
                return BadRequest("Could not edit outcome measurement.");
            }

            editedOutcomeMeasurement = await _studentService.GetOutcomeAsync(editedOutcomeMeasurement.OutcomeId);

            return RedirectToAction("OutcomeIndex", "Student", new { id = editedOutcomeMeasurement.Student.StudentId });

        }
    }
}