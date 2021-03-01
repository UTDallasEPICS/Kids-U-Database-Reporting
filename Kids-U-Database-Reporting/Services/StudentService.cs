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

        public async Task<Student[]> GetStudentsAsync() // Get all students, no filtering
        {
            return await _context.Students.ToArrayAsync();
        }
        public async Task<Student[]> GetStudentsAsync(Search s) // Returns list of all students matching the parameters passed
        {
            // Convert string from search form to bool used in database. Needed since the string is tested to be null for no input and bool can't be null
            bool lunchBool = s.Lunch == "True";
            bool activeBool = s.Active == "True";
            int year = DateTime.Now.Year;

            var students = _context.Students
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

            return await students.ToArrayAsync();
        }
        public async Task<Student[]> GetStudentsWithReportCardsAsync(Search s) // Returns list of all students matching the parameters passed, with report card data loaded
        {
            // Convert string from search form to bool used in database. Needed since the string is tested to be null for no input and bool can't be null
            bool lunchBool = s.Lunch == "True";
            bool activeBool = s.Active == "True";
            int year = DateTime.Now.Year;

            var students = _context.Students
                .Include(s => s.ReportCards) // .Include() loads the ReportCards, otherwise it is just a reference without the actual data
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

            return await students.ToArrayAsync();
        }

        public async Task<bool> AddStudentAsync(Student newStudent)
        {
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
        public async Task<Student> GetStudentById(int Id)
        {
            return await _context.Students.Where(x => x.StudentId == Id).FirstAsync();
        }
        public async Task<Student> EditStudentAsync(int Id)
        {
            //returns student by id
            return await _context.Students.Where(x => x.StudentId == Id).FirstAsync();
        }

        public async Task<bool> ApplyEditStudentAsync(Student editedStudent)
        {
            //_context.Students.Update(editedStudent);
            _context.Entry(await _context.Students.FirstAsync(x => x.StudentId == editedStudent.StudentId)).CurrentValues.SetValues(editedStudent);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }









        //OUTCOME MEASUREMENTS STUFF STARTS HERE

        public async Task<OutcomeMeasurement[]> GetOutcomesAsync(int Id)
        {
            //returns all outcome measurements for a Student
            Student student = await _context.Students.Where(x => x.StudentId == Id).FirstAsync();
            return await _context.OutcomeMeasurements.Where(x => x.Student == student).ToArrayAsync();
        }

        public async Task<OutcomeMeasurement> GetOutcomeAsync(int Id)
        {
            //returns single outcome measurement from outcome measurement id
            return await _context.OutcomeMeasurements.Where(x => x.OutcomeId == Id).Include(r => r.Student).FirstAsync();
        }

        public async Task<bool> SubmitNewOutcomeAsync(OutcomeMeasurement newOutcomeMeasurement)
        {
            //puts new outcome measurement in database

            //gets the student the outcome measurement is for from the database
            Student student = await _context.Students.Where(x => x.StudentId == newOutcomeMeasurement.Student.StudentId).FirstAsync();

            newOutcomeMeasurement.Student = student;
            await _context.OutcomeMeasurements.AddAsync(newOutcomeMeasurement);

            //adds outcome measurement to the student
            student.OutcomeMeasurements.Add(newOutcomeMeasurement);

            //updates student in database
            _context.Entry(await _context.Students.FirstAsync(x => x.StudentId == student.StudentId)).CurrentValues.SetValues(student);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> ApplyEditOutcomeAsync(OutcomeMeasurement editedOutcomeMeasurement)
        {
            _context.Entry(await _context.OutcomeMeasurements.FirstAsync(x => x.OutcomeId == editedOutcomeMeasurement.OutcomeId)).CurrentValues.SetValues(editedOutcomeMeasurement);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
