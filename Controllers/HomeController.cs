using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }

        public ActionResult Directory()
        {
            return View();
        }

        public ActionResult Students()
        {
            return View();
        }

        public ActionResult OutcomeMeasurements()
        {
            return View();
        }

        public ActionResult ReportCardRecords()
        {
            return View();
        }

        public ActionResult Organizations()
        {
            return View();
        }

        public ActionResult SchoolDistricts()
        {
            return View();
        }

        public ActionResult Schools()
        {
            return View();
        }

        public ActionResult Sites()
        {
            return View();
        }

        public ActionResult Staff()
        {
            return View();
        }
    }
}
