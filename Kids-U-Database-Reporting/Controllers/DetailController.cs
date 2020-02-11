using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kids_U_Database_Reporting.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult ShowOutcomeMeasurements()
        {
            return View();
        }
    }
}