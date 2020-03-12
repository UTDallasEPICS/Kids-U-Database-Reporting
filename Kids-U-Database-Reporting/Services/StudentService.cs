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
        public async Task<Student[]> GetStudentsAsync()
        {
            //returns all Students in Student database
            return await _context.Students
                //.Where(x => x.IsDone == false) //example of how to filter for search with LINQ query
                .ToArrayAsync();
        }

        public async Task<bool> AddStudentAsync(Student newStudent)
        {
            //puts new student in database
            _context.Students.Add(newStudent);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> DeleteStudentAsync(int Id)
        {
            //deletes student in database by id
            Student deleteStudent = await _context.Students.Where(x => x.StudentId == Id).FirstAsync();
            _context.Students.Remove(deleteStudent);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        public async Task<Student> EditStudentAsync(int Id)
        {
            //returns student by id
            return await _context.Students.Where(x => x.StudentId == Id).FirstAsync();
        }
    }
}
