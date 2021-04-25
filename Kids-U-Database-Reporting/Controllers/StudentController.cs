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
        public async Task<IActionResult> Index(Search searchData)
        {
            // Get all students who match the parameters
            var items = await _studentService.GetStudents(searchData, User.Identity.Name);
            searchData.ResultCount = items.Length;

            // Create model with the students and search data
            StudentViewModel model = new StudentViewModel()
            {
                Students = items,
                SearchData = searchData,
            };

            ViewBag.resultPercent = (100.0 * items.Length / _studentService.GetActiveStudentCount()).ToString("n1"); // Percent of active students visible in search results, formatted to 1 decimal point
            ViewBag.returnUrl = Url.Action()+Request.QueryString; // Get the current url with query string to preserve search settings
            ViewBag.selectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View(model);
        }

        public async Task<IActionResult> View(int studentId, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            var student = await _studentService.GetStudent(studentId, User.Identity.Name);
            if (student == null)
                return BadRequest("Could not access student");
            else
                return View(student);
        }

        // Go to form for adding a new student
        public async Task<IActionResult> Add(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View();
        }

        // Puts newly created student into database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Student newStudent)
        {
            var successful = await _studentService.AddStudent(newStudent);

            if (!successful)
                return BadRequest("Could not add student.");

            return RedirectToAction("Index", "Student");
        }

        //goes to form to edit student
        public async Task<IActionResult> Edit(int studentId, string returnUrl)
        {
            var model = await _studentService.GetStudent(studentId, User.Identity.Name);
            ViewBag.returnUrl = returnUrl;
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View(model);
        }

        // Submit edits of student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student editedStudent, string returnUrl)
        {
            var successful = await _studentService.ApplyEditStudent(editedStudent);

            if (!successful)
                return BadRequest("Could not edit student.");

            if(returnUrl != null)
                return RedirectToAction("View", "Student", new { editedStudent.StudentId, returnUrl });
            else
                return RedirectToAction("Index", "Student");
        }

        // Deletes Student and attached ReportCards and OutcomeMeasurements from database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int studentId, string returnUrl)
        {
            await _studentService.DeleteStudent(studentId);
            return Redirect(returnUrl); // Redirect to the same index page so search parameters are preserved
        }

        // Export a csv of all student data https://stackoverflow.com/a/62125940
        public async Task<ActionResult> Export(Search searchData) 
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecords(await _studentService.GetStudents(searchData, User.Identity.Name));
            }
            return File(ms.ToArray(), "text/csv", $"StudentData_{DateTime.UtcNow.Date:d}.csv");
        }

        // Export a csv of a single student's data
        public async Task<ActionResult> ExportSingle(int studentId)
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));

            using var ms = new MemoryStream();
            using var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));
            using (var cw = new CsvWriter(sw, cc))
            {
                cw.WriteRecord(await _studentService.GetStudent(studentId, User.Identity.Name));
            }
            return File(ms.ToArray(), "text/csv", $"Student_{DateTime.UtcNow.Date:d}.csv");
        }
    }
}