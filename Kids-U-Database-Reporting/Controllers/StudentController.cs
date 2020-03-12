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
            //constructor
            _studentService = studentService;
        }
        
        public async Task<IActionResult> Index()
        {
            //displays all students

            var items = await _studentService.GetStudentsAsync();
            var model = new StudentViewModel()

            {
                Students = items
            };
            return View(model);
        }

        public IActionResult Add()
        {
            //goes to view to create student
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student newStudent)
        {
            //puts new student in database

            var successful = await _studentService.AddStudentAsync(newStudent);

            if (!successful)
            {
                return BadRequest("Could not add student.");
            }
            return RedirectToAction("Index", "Student");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            //deletes student from database
            var successful = await _studentService.DeleteStudentAsync(Id);

            if (!successful)
            {
                return BadRequest("Could not delete Student.");
            }
            return RedirectToAction("Index", "Student");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            //goes to view to edit student
            var model = new Student();
            model = await _studentService.EditStudentAsync(Id);
            
            return View(model);
        }

        public async Task<IActionResult> SubmitEdit(Student newStudent)
        {
            //submits eddits

            /*var successful = await _studentService.EditStudentAsync(newStudent);

            if (!successful)
            {
                return BadRequest("Could not edit student.");
            }
            */
            return RedirectToAction("Index", "Student");

        }


        /*
        public async Task<IActionResult> Details(int Id)
        {

        }
        */

        

    }
}