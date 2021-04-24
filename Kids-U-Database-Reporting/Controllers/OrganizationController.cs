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
        private readonly IOrganizationsService _organizationService;
        public OrganizationController(IOrganizationsService organizationService)
        {
            _organizationService = organizationService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _organizationService.GetOrganizationsAsync();
            var model = new OrganizationViewModel()
            {
                Organizations = items
            };
            return View(model);
        }

        public async Task<IActionResult> View(int organizationId)
        {
            Organization organization = await _organizationService.GetOrganization(organizationId);
            return View(organization);
        }

        public IActionResult Add()
        {
            return View();
        }

        // Submits new org to database
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Add(Organization newOrganization)
        {
            var successful = await _organizationService.AddOrganizationAsync(newOrganization);

            if (!successful)
            {
                return BadRequest("Could not add Organization.");
            }

            return RedirectToAction("Index", "Organization");
        }

        public async Task<IActionResult> Edit(int organizationId)
        {
            return View(await _organizationService.GetOrganization(organizationId));
        }

        // Submits edit of org to database
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(Organization editedOgranization)
        {
            var successful = await _organizationService.ApplyEditOrganizationAsync(editedOgranization);

            if (!successful)
            {
                return BadRequest("Could not edit Organization.");
            }

            return RedirectToAction("Index", "Organization");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int organizationId)
        {
            var successful = await _organizationService.DeleteOrganizationAsync(organizationId);

            if (!successful)
            {
                return BadRequest("Could not delete Organization.");
            }
            return RedirectToAction("Index", "Organization");
        }
    }
}
