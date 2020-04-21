using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class SchoolService : ISchoolService
    {

        private readonly ApplicationDbContext _context;


        public SchoolService(ApplicationDbContext context)
        {
            //new instance of service is made during each request (required for talking to database) aka scoped lifecycle
            _context = context;
        }
        public async Task<School[]> GetSchoolsAsync()
        {
            return await _context.Schools
               .ToArrayAsync();
        }

        public async Task<School> EditSchoolAsync(int Id)
        {
            return await _context.Schools.Where(x => x.SchoolId == Id).FirstAsync();
        }

        public async Task<bool> DeleteSchoolAsync(int Id)
        {
            School deleteSchool = await _context.Schools.Where(x => x.SchoolId == Id).FirstAsync();
            _context.Schools.Remove(deleteSchool);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> AddSchoolAsync(School newSchool)
        {
            _context.Schools.Add(newSchool);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        public async Task<bool> ApplyEditStudentAsync(School editedSchool)
        {
            //_context.Students.Update(editedStudent);
            _context.Entry(await _context.Schools.FirstAsync(x => x.SchoolId == editedSchool.SchoolId)).CurrentValues.SetValues(editedSchool);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
