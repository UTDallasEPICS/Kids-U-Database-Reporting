using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kids_U_Database_Reporting.Services;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kids_U_Database_Reporting.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISchoolService _schoolService;
        private readonly ISiteService _siteService;
        
        public StudentController(IStudentService studentService, ISchoolService schoolService, ISiteService siteService)
        {
            //constructor

            _studentService = studentService;
            _schoolService = schoolService;
            _siteService = siteService;
        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> Index()
        {
            //displays all students

            var items = await _studentService.GetStudentsAsync();

            var model = new StudentViewModel()
            {
                Students = items
            };
            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> AddAsync()
        {
            //goes to form to create student


            //this part is for dynamically allocating school list
            var items = await _schoolService.GetSchoolsAsync();
            List<String> schoolList = new List<string>();

            schoolList.Add("Select School");

            foreach (School school in items)
            {
                schoolList.Add(school.SchoolName);
            }
            ViewBag.SchoolList = schoolList;
            
            var locations = await _siteService.GetSitesAsync();
            List<String> siteList = new List<string>();

            siteList.Add("Select KU Site");

            foreach (Site site in locations)
            {
                siteList.Add(site.SiteName);
            }
            ViewBag.SiteList = siteList;



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
        public async Task<IActionResult> Edit(int Id)
        {
            //goes to form to edit student

            var model = new Student();

            model = await _studentService.EditStudentAsync(Id);


            //this part is for dynamically allocating school list
            var items = await _schoolService.GetSchoolsAsync();
            List<String> schoolList = new List<string>();

            schoolList.Add("Select School");

            foreach (School school in items)
            {
                schoolList.Add(school.SchoolName);
            }
            ViewBag.SchoolList = schoolList;

            var locations = await _siteService.GetSitesAsync();
            List<String> siteList = new List<string>();

            siteList.Add("Select KU Site");

            foreach (Site site in locations)
            {
                siteList.Add(site.SiteName);
            }
            ViewBag.SiteList = siteList;



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







        //REPORT CARD STUFF STARTS HERE
        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> ReportCardIndex(int Id)
        {
            //displays all report cards for one student

            var items = await _studentService.GetReportCardsAsync(Id);

            var model = new ReportCardViewModel()
            {
                ReportCards = items
            };

            //EditStudentAsync actually returns a student based on id... it is poorly named
            model.Student = await _studentService.EditStudentAsync(Id);

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
            {
                return BadRequest("Could not add report card.");
            }

            return RedirectToAction("ReportCardIndex", "Student", new { id = newReportCard.Student.StudentId });


        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> EditReportCard(int Id)
        {
            //goes to form to edit report card

            var model = new ReportCard();

            model = await _studentService.GetReportCardAsync(Id);

            return View(model);
        }

        public async Task<IActionResult> ApplyEditReportCard(ReportCard editedReportCard)
        {
            //submit edit of report card
            var successful = await _studentService.ApplyEditReportCardAsync(editedReportCard);

            if (!successful)
            {
                return BadRequest("Could not edit report card.");
            }

            editedReportCard = await _studentService.GetReportCardAsync(editedReportCard.ReportCardId);

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
                OutcomeMeasurements = items
            };

            //EditStudentAsync actually returns a student based on id... it is poorly named
            model.Student = await _studentService.EditStudentAsync(Id);

            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> CreateOutcome(int Id)
        {
            //goes to form to create outcome measurement

            Student student = await _studentService.EditStudentAsync(Id);

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

            var model = new OutcomeMeasurement();

            model = await _studentService.GetOutcomeAsync(Id);

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