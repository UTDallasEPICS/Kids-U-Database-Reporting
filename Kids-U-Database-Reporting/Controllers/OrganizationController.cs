using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kids_U_Database_Reporting.Models;
using Kids_U_Database_Reporting.Services;

namespace Kids_U_Database_Reporting.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationsService _orgaizationService;
        public OrganizationController(IOrganizationsService orgaizationService)
        {
            //constructor
            _orgaizationService = orgaizationService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _orgaizationService.GetOrganizationsAsync();
            var model = new OrganizationViewModel()

            {
                Organizations = items
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var model = new Organization();
            model = await _orgaizationService.EditOrganizationAsync(Id);

            return View(model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var successful = await _orgaizationService.DeleteOrganizationAsync(Id);

            if (!successful)
            {
                return BadRequest("Could not delete Organization.");
            }
            return RedirectToAction("Index", "Organization");
        }

        public async Task<IActionResult> CreateOrganization(Organization newOrganization)
        {
            //puts new student in database

            var successful = await _orgaizationService.AddOrganizationAsync(newOrganization);

            if (!successful)
            {
                return BadRequest("Could not add Organization.");
            }

            return RedirectToAction("Index", "Organization");
        }

        public async Task<IActionResult> ApplyEdit(Organization editedOgranization)
        {
            //submit edits of District

            var successful = await _orgaizationService.ApplyEditOrganizationAsync(editedOgranization);

            if (!successful)
            {
                return BadRequest("Could not edit Organization.");
            }

            return RedirectToAction("Index", "Organization");

        }
    }
}
