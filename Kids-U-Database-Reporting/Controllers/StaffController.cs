using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;
using Kids_U_Database_Reporting.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Global Administrator, Site Administrator")]
        public async Task<IActionResult> Index()
        {
            var items = await _staffService.GetAllStaffAsync();
            var model = new ApplicationUserViewModel()
            {
                Users = items
            };
            return View(model);
        }
        [Authorize(Roles = "Global Administrator")]
        public async Task<IActionResult> Edit(string Email)
        {
            var staff = new ApplicationUser();
            staff = await _staffService.GetStaffAsync(Email);

            return View(staff);
        }

        public async Task<IActionResult> FinalizeEditAsync(ApplicationUser model)
        {
           var result = await _staffService.UpdateStaffAsync(model);
            if(result == 1)
            {
                Console.WriteLine("update worked");
            }
            else
            {
                Console.WriteLine("update failed");
            }
           return RedirectToAction("Index", "Staff");
        }

        [Authorize(Roles = "Global Administrator")]
        public async Task<IActionResult> Delete(string Email)
        {
            await _staffService.DeleteStaffAsync(Email);
            return RedirectToAction("Index", "Staff");
        }
    }
}