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
            var items = await _studentService.GetStudentsAsync();
            var model = new StudentViewModel()

            {
                Students = items
            };
            
            //put items into a model
            //pass view to model and render

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(Student newStudent)
        {
            Console.WriteLine("beginning");
            /*
            if (!ModelState.IsValid)
            {
                Console.WriteLine("not valid");
                return RedirectToAction("Index", "Student");
            }
            */
            Console.WriteLine("pre call");
            var successful = await _studentService.AddStudentAsync(newStudent);
            Console.WriteLine(successful);

            if (!successful)
            {
                return BadRequest("Could not add student.");
            }
            return RedirectToAction("Index", "Student");
        }

        public IActionResult CreateStudent()
        {
            return View();
        }


    }
}