using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;
using Kids_U_Database_Reporting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kids_U_Database_Reporting.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;
        private readonly IDistrictService _districtService;
        public SchoolController(ISchoolService schoolService, IDistrictService districtService)
        {
            //constructor
            _schoolService = schoolService;
            _districtService = districtService;
        }

        [Authorize(Roles = "Global Administrator, Site Administrator,Site Volunteer")]
        public async Task<IActionResult> Index()
        {
            var items = await _schoolService.GetSchoolsAsync();
            var model = new SchoolViewModel()
            {
                Schools = items
            };
            return View(model);
        }

        [Authorize(Roles = "Global Administrator")]
        public async Task<IActionResult> CreateAsync()
        {
            
            //this part is for dynamically allocating district list
            var items = await _districtService.GetDistrictsAsync();
            List<String> districtList = new List<string>();

            districtList.Add("Select District");

            foreach (District district in items)
            {
                districtList.Add(district.DistrictName);
            }
            ViewBag.DistrictList = districtList;



            return View();
        }

        [Authorize(Roles = "Global Administrator")]
        public async Task<IActionResult> Edit(int Id)
        {
            var model = new School();
            model = await _schoolService.EditSchoolAsync(Id);

            //this part is for dynamically allocating district list
            var items = await _districtService.GetDistrictsAsync();
            List<String> districtList = new List<string>();

            districtList.Add("Select District");

            foreach (District district in items)
            {
                districtList.Add(district.DistrictName);
            }
            ViewBag.DistrictList = districtList;


            return View(model);
        }

        [Authorize(Roles = "Global Administrator")]
        public async Task<IActionResult> Delete(int Id)
        {
            var successful = await _schoolService.DeleteSchoolAsync(Id);

            if (!successful)
            {
                return BadRequest("Could not delete School.");
            }
            return RedirectToAction("Index", "School");
        }

        public async Task<IActionResult> CreateSchool(School newSchool)
        {
            //puts new student in database

            var successful = await _schoolService.AddSchoolAsync(newSchool);

            if (!successful)
            {
                return BadRequest("Could not add School.");
            }

            return RedirectToAction("Index", "School");
        }

        public async Task<IActionResult> ApplyEdit(School editedSchool)
        {
            //submit edits of student

            var successful = await _schoolService.ApplyEditStudentAsync(editedSchool);

            if (!successful)
            {
                return BadRequest("Could not edit School.");
            }

            return RedirectToAction("Index", "School");

        }
    }
}