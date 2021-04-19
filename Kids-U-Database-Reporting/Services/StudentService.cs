using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private const string adminRole = "Global Administrator"; // adminRole is able to see students from all sites

        public StudentService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            //new instance of service is made during each request (required for talking to database) aka scoped lifecycle
            _context = context;
            _userManager = userManager;
        }

        // Return an int with the number of active students
        public int GetActiveStudentCount()
        {
            return _context.Students.Count(x => x.Active);
        }

        // Return a Student using the StudentId
        public async Task<Student> GetStudent(int studentId, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName); // Get the current user from userName
            var student = await _context.Students.FindAsync(studentId);
            return (user.Role == adminRole || student.Facility == user.Site) ? student : null; // Only return student if user is admin or student is at user's site
        }

        // Returns list of all students matching the parameters passed. Restricts to only sites the user has access to
        public async Task<Student[]> GetStudents(Search s, string userName) 
        {
            var user = await _userManager.FindByNameAsync(userName); // Get the current user from userName
            var students = _context.Students.Where(x => user.Role == adminRole || x.Facility.Equals(user.Site)); // Check that user is admin or student is at the user's site

            students = FilterAndSort(s, students);

            return await students.ToArrayAsync();
        }

        // Returns list of all students matching the search filters, with Report Card data included
        public async Task<Student[]> GetStudentsWithReportCards(Search s, string userName) 
        {
            var user = await _userManager.FindByNameAsync(userName); // Get the current user from userName
            var students = _context.Students
                .Include(s => s.ReportCards) // .Include() loads the ReportCards, otherwise it is just a reference without the actual data
                .Where(x => user.Role == adminRole || x.Facility.Equals(user.Site)); // Check that user is admin or student is at the user's site

            students = FilterAndSort(s, students);

            return await students.ToArrayAsync();
        }

        // Returns list of all students matching the search filters, with Outcome Measurement data included
        public async Task<Student[]> GetStudentsWithOutcomes(Search s, string userName) 
        {
            var user = await _userManager.FindByNameAsync(userName); // Get the current user from userName
            var students = _context.Students
                .Include(s => s.OutcomeMeasurements)
                .Where(x => user.Role == adminRole || x.Facility.Equals(user.Site)); // Check that user is admin or student is at the user's site

            students = FilterAndSort(s, students);

            return await students.ToArrayAsync();
        }

        public async Task<bool> AddStudent(Student newStudent)
        {
            _context.Students.Add(newStudent);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        // Deletes Student in database by id, also delete related ReportCards and OutcomeMeasurements
        public async Task<bool> DeleteStudent(int studentId)
        {
            Student deleteStudent = await _context.Students.Include(s => s.ReportCards).Include(s => s.OutcomeMeasurements).Where(s => s.StudentId == studentId).FirstAsync();
            _context.Students.Remove(deleteStudent);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> ApplyEditStudent(Student editedStudent)
        {
            //_context.Students.Update(editedStudent);
            _context.Entry(await _context.Students.FirstAsync(x => x.StudentId == editedStudent.StudentId)).CurrentValues.SetValues(editedStudent);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        // Apply search filters and sorting to a list of students
        private IQueryable<Student> FilterAndSort(Search s, IQueryable<Student> students)
        {
            // Convert string from search form to bool used in database
            bool lunchBool = s.Lunch == "True";
            bool activeBool = s.Active == "True";
            int year = DateTime.Now.Year;

            students = students
                .Where(x => s.Name == null || x.FirstName.Contains(s.Name) || x.LastName.Contains(s.Name))
                .Where(x => s.Ethnicity == null || x.Ethnicity.Equals(s.Ethnicity))
                .Where(x => s.Gender == null || x.Gender.Equals(s.Gender))
                .Where(x => s.School == null || s.School.Equals("Select School") || x.SchoolName.Equals(s.School))
                .Where(x => s.Lunch == null || x.Lunch == lunchBool)
                .Where(x => s.Income == null || x.Income.Equals(s.Income))
                .Where(x => s.Active == null || x.Active == activeBool)
                .Where(x => s.SchoolGrade == null || x.SchoolGrade.Equals(s.SchoolGrade))
                .Where(x => s.YearsEnrolled == null || year - x.EnrolledYear == int.Parse(s.YearsEnrolled))
                .Where(x => s.Site == null || s.Site.Equals("Select KU Site") || x.Facility.Equals(s.Site));

            switch (s.SortOrder)
            {
                case "0": break; // Default is no sorting applied
                case "1": students = students.OrderBy(s => s.FirstName); break;
                case "2": students = students.OrderByDescending(s => s.FirstName); break;
                case "3": students = students.OrderBy(s => s.LastName); break;
                case "4": students = students.OrderByDescending(s => s.LastName); break;
                case "5": students = students.OrderByDescending(s => s.Active); break; // Active ("True") first
                case "6": students = students.OrderBy(s => s.Active); break; // Inactive ("False") first
                case "7": students = students.OrderBy(s => s.SchoolName); break;
                case "8": students = students.OrderByDescending(s => s.SchoolName); break;
                case "9": students = students.OrderBy(s => s.Facility); break;
                case "10": students = students.OrderByDescending(s => s.Facility); break;
                case "11": students = students.OrderBy(s => s.SchoolGrade); break;
                case "12": students = students.OrderByDescending(s => s.SchoolGrade); break;
            }

            return students;
        }
    }
}
