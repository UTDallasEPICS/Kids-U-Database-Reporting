using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;


        public StudentService(ApplicationDbContext context)
        {
            //new instance of service is made during each request (required for talking to database) aka scoped lifecycle
            _context = context;
        }

        //TODO: add search parameters to method call 
        public async Task<Student[]> GetIncompleteItemsAsync()
        {
            //returns all items in Student
            return await _context.Students
                //.Where(x => x.IsDone == false) //example of how to filter for search with LINQ query
                .ToArrayAsync();
        }

        public async Task<bool> AddStudentAsync(Student newStudent)
        {

           
            _context.Students.Add(newStudent);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
