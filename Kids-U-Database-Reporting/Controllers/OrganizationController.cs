using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kids_U_Database_Reporting.Models;
using Kids_U_Database_Reporting.Services;
using Microsoft.AspNetCore.Authorization;

namespace Kids_U_Database_Reporting.Controllers
{
    [Authorize(Roles = "Global Administrator")]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationsService _orgaizationService;
        public OrganizationController(IOrganizationsService orgaizationService)
        {
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
            return View(await _orgaizationService.EditOrganizationAsync(Id));
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

        //puts new student in database
        public async Task<IActionResult> CreateOrganization(Organization newOrganization)
        {
            var successful = await _orgaizationService.AddOrganizationAsync(newOrganization);

            if (!successful)
            {
                return BadRequest("Could not add Organization.");
            }

            return RedirectToAction("Index", "Organization");
        }

        //submit edits of District
        public async Task<IActionResult> ApplyEdit(Organization editedOgranization)
        {
            var successful = await _orgaizationService.ApplyEditOrganizationAsync(editedOgranization);

            if (!successful)
            {
                return BadRequest("Could not edit Organization.");
            }

            return RedirectToAction("Index", "Organization");

        }
    }
}
