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
            _context = context;
        }

        public async Task<Student[]> GetIncompleteItemsAsync()
        {
            return await _context.Students
                //.Where(x => x.IsDone == false) //example of how to filter for search
                .ToArrayAsync();
        }
    }
}
