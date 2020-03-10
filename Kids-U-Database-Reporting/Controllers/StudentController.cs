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

        //displays all students
        public async Task<IActionResult> Index()
        {
            var items = await _studentService.GetStudentsAsync();
            var model = new StudentViewModel()

            {
                Students = items
            };
            return View(model);
        }

        //makes new students
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student newStudent)
        {
            /* not working properly but is kind of a reduntant check?
            if (!ModelState.IsValid)
            {
                Console.WriteLine("not valid");
                return RedirectToAction("Index", "Student");
            }
            */
            var successful = await _studentService.AddStudentAsync(newStudent);

            if (!successful)
            {
                return BadRequest("Could not add student.");
            }
            return RedirectToAction("Index", "Student");
        }

        public async Task<IActionResult> Delete(int Id)
        {

            var successful = await _studentService.DeleteStudentAsync(Id);

            if (!successful)
            {
                return BadRequest("Could not delete Student.");
            }
            return RedirectToAction("Index", "Student");
        }

        public async Task<IActionResult> Edit(int Id)
        {

        }

        public async Task<IActionResult> Details(int Id)
        {

        }


    }
}