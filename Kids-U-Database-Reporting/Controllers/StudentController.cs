using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kids_U_Database_Reporting.Services;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            
            //get students from database
            var items = await _studentService.GetIncompleteItemsAsync();
            var model = new StudentViewModel()
            {
                Students = items
            };
            
            //put items into a model
            //pass view to model and render

            return View(model);
        }


    }
}