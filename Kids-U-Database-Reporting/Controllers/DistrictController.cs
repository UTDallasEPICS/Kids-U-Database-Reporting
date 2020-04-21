using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;
using Kids_U_Database_Reporting.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kids_U_Database_Reporting.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService districtService)
        {
            //constructor
            _districtService = districtService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _districtService.GetDistrictsAsync();
            var model = new DistrictViewModel()

            {
                Districts = items
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var model = new District();
            model = await _districtService.EditDistrictAsync(Id);

            return View(model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var successful = await _districtService.DeleteDistrictAsync(Id);

            if (!successful)
            {
                return BadRequest("Could not delete District.");
            }
            return RedirectToAction("Index", "District");
        }

        public async Task<IActionResult> CreateDistrict(District newDistrict)
        {
            //puts new student in database

            var successful = await _districtService.AddDistrictAsync(newDistrict);

            if (!successful)
            {
                return BadRequest("Could not add District.");
            }

            return RedirectToAction("Index", "District");
        }

        public async Task<IActionResult> ApplyEdit(District editedDistrict)
        {
            //submit edits of District

            var successful = await _districtService.ApplyEditDistrictAsync(editedDistrict);

            if (!successful)
            {
                return BadRequest("Could not edit District.");
            }

            return RedirectToAction("Index", "District");

        }
    }
}