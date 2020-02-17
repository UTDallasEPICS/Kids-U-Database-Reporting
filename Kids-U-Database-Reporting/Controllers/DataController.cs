using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public  IActionResult Students()
        {
            return View();
        }

        public IActionResult Sites()
        {
            return View();
        }
    }
}