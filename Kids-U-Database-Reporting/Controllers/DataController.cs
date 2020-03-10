using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kids_U_Database_Reporting.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Organizations()
        {
            return View();
        }

     
        public IActionResult OutcomeMeasurements()
        {
            return View();
        }

        public IActionResult ReportCardRecords()
        {
            return View();
        }

        public IActionResult SchoolDistricts()
        {
            return View();
        }

        public IActionResult Schools()
        {
            return View();
        }

        public IActionResult Staff()
        {
            return View();
        }

        public async Task<IActionResult> StudentsAsync()
        {
            // get students from database
             var items = await _studentService.GetIncompleteItemsAsync();
            var model = new StudentViewModel()

            {
                Students = items
            };

            //put items into a model
            //pass view to model and render

            return View(model);
        }

        public IActionResult Sites()
        {
            return View();
        }
    }
}