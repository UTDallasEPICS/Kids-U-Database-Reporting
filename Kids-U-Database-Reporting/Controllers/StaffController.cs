using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;
using Kids_U_Database_Reporting.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kids_U_Database_Reporting.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _staffService.GetAllStaffAsync();
            var model = new ApplicationUserViewModel()
            {
                Users = items
            };
            return View(model);
        }
        public async Task<IActionResult> Edit(string Email)
        {
            var model = new ApplicationUser();
            model = await _staffService.GetStaffAsync(Email);

            return View(model);
        }

        public IActionResult FinalizeEdit(ApplicationUser model)
        {
            
           return RedirectToAction("Index", "Staff");
        }
    }
}