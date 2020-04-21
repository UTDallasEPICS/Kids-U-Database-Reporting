using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;
using Kids_U_Database_Reporting.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kids_U_Database_Reporting.Controllers
{
    public class SiteController : Controller
    {
        private readonly ISiteService _siteService;
        public SiteController(ISiteService siteService)
        {
            //constructor
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
            var model = new Site();
            model = await _siteService.EditSiteAsync(Id);

            return View(model);
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

        public async Task<IActionResult> CreateSite(Site newSite)
        {
            //puts new student in database

            var successful = await _siteService.AddSiteAsync(newSite);

            if (!successful)
            {
                return BadRequest("Could not add Site.");
            }

            return RedirectToAction("Index", "Site");
        }

        public async Task<IActionResult> ApplyEdit(Site editedSite)
        {
            //submit edits of District

            var successful = await _siteService.ApplyEditSiteAsync(editedSite);

            if (!successful)
            {
                return BadRequest("Could not edit Site.");
            }

            return RedirectToAction("Index", "Site");

        }
    }
}