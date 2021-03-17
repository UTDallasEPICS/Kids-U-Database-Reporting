﻿using System;
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
            var items = await _studentService.GetStudents(searchData);
            searchData.ResultCount = items.Length;

            // Create model with the students and search data
            StudentViewModel model = new StudentViewModel()
            {
                Students = items,
                SearchData = searchData,
            };

            ViewBag.selectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View(model);
        }

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> Add()
        {
            //goes to form to create student

            ViewBag.SchoolList = await _commonService.GetSchoolSelectList();
            ViewBag.SiteList = await _commonService.GetSiteSelectList();
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student newStudent)
        {
            //puts new student in database

            var successful = await _studentService.AddStudent(newStudent);

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

            var successful = await _studentService.DeleteStudent(Id);

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
            ViewBag.SelectLists = new SelectLists
            {
                SchoolList = await _commonService.GetSchoolSelectList(),
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View(model);
        }

        public async Task<IActionResult> ApplyEdit(Student editedStudent)
        {
            //submit edits of student

            var successful = await _studentService.ApplyEditStudent(editedStudent);

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
                cw.WriteRecords(await _studentService.GetStudents(searchData));
            }
            return File(ms.ToArray(), "text/csv", $"StudentData_{DateTime.UtcNow.Date:d}.csv");
        }


        //OUTCOME MEASUREMENTS STUFF STARTS HERE
        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> OutcomeIndex(int Id)
        {
            //displays all outcome measurements for one student

            var items = await _studentService.GetOutcomes(Id);

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

            var successful = await _studentService.SubmitNewOutcome(newOutcomeMeasurement);

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

            var model = await _studentService.GetOutcome(Id);

            return View(model);
        }

        public async Task<IActionResult> ApplyEditOutcome(OutcomeMeasurement editedOutcomeMeasurement)
        {
            //submit edit of report card
            var successful = await _studentService.ApplyEditOutcome(editedOutcomeMeasurement);

            if (!successful)
            {
                return BadRequest("Could not edit outcome measurement.");
            }

            editedOutcomeMeasurement = await _studentService.GetOutcome(editedOutcomeMeasurement.OutcomeId);

            return RedirectToAction("OutcomeIndex", "Student", new { id = editedOutcomeMeasurement.Student.StudentId });

        }
    }
}