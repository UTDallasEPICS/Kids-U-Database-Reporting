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
            if(ModelState.IsValid)
            {
                await _organizationService.AddOrganizationAsync(newOrganization);
                return RedirectToAction("Index", "Organization");
            }
            return View(newOrganization); // Return to form if it is invalid
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
            if (ModelState.IsValid)
            {
                await _organizationService.ApplyEditOrganizationAsync(editedOgranization);
                return RedirectToAction("Index", "Organization");
            }
            return View(editedOgranization); // Return to form if it is invalid
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
