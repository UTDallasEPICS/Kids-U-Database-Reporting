using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kids_U_Database_Reporting.Controllers
{
    public class CreateController : Controller
    {
        public IActionResult CreateOrganization()
        {
            return View();
        }

        public IActionResult CreateOutcomeMeasurements()
        {
            return View();
        }

        public IActionResult CreateReportCards()
        {
            return View();
        }

        public IActionResult CreateSchoolDistricts()
        {
            return View();
        }

        public IActionResult CreateSchools()
        {
            return View();
        }

        public IActionResult CreateSites()
        {
            return View();
        }

        public IActionResult CreateStaff()
        {
            return View();
        }

        public IActionResult CreateStudents()
        {
            return View();
        }
    }
}