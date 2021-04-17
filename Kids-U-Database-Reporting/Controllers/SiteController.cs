using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;
using Kids_U_Database_Reporting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kids_U_Database_Reporting.Controllers
{
    [Authorize(Roles = "Global Administrator")]
    public class SiteController : Controller
    {
        private readonly ISiteService _siteService;
        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _siteService.GetSitesAsync();
            var model = new SiteViewModel()
            {
                Sites = items
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            return View(await _siteService.EditSiteAsync(Id));
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var successful = await _siteService.DeleteSiteAsync(Id);

            if (!successful)
            {
                return BadRequest("Could not delete Site.");
            }
            return RedirectToAction("Index", "Site");
        }

        //puts new student in database
        public async Task<IActionResult> CreateSite(Site newSite)
        {
            var successful = await _siteService.AddSiteAsync(newSite);

            if (!successful)
            {
                return BadRequest("Could not add Site.");
            }

            return RedirectToAction("Index", "Site");
        }

        //submit edits of District
        public async Task<IActionResult> ApplyEdit(Site editedSite)
        {
            var successful = await _siteService.ApplyEditSiteAsync(editedSite);

            if (!successful)
            {
                return BadRequest("Could not edit Site.");
            }

            return RedirectToAction("Index", "Site");
        }
    }
}