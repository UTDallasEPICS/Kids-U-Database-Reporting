using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;
using Kids_U_Database_Reporting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kids_U_Database_Reporting.Controllers
{
    [Authorize(Roles = "Global Administrator")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly ICommonService _commonService;

        public StaffController(IStaffService staffService, ICommonService commonService)
        {
            _staffService = staffService;
            _commonService = commonService;
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

        public async Task<IActionResult> Add()
        {
            ViewBag.selectLists = new SelectLists()
            {
                SiteList = await _commonService.GetSiteSelectList()
            };

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ApplicationUser newUser, string password)
        {
            await _staffService.AddNewStaff(newUser, password);
            return RedirectToAction("Index", "Staff");
        }

        public async Task<IActionResult> Edit(string Email)
        {
            ViewBag.selectLists = new SelectLists()
            {
                SiteList = await _commonService.GetSiteSelectList()
            };
            var staff = await _staffService.GetStaffAsync(Email);
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser model, string oldEmail, string password)
        {
           await _staffService.UpdateStaffAsync(model, oldEmail, password);
           return RedirectToAction("Index", "Staff");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string Email)
        {
            await _staffService.DeleteStaffAsync(Email);
            return RedirectToAction("Index", "Staff");
        }
    }
}