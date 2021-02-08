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

        // Returns list of all students matching the parameters passed
        public async Task<Student[]> GetStudentsAsync(Search s)
        {
            // Convert string from input form to bool used in database. Needed since string is tested to be null for no input and bool can't be null
            bool lunchBool = s.Lunch == "True";
            bool activeBool = s.Active == "True";
            int year = DateTime.Now.Year;

            return await _context.Students
                .Where(x => s.Name ==null || x.FirstName.Contains(s.Name) || x.LastName.Contains(s.Name)) 
                .Where(x => s.Ethnicity==null || x.Ethnicity.Equals(s.Ethnicity)) 
                .Where(x => s.Gender==null || x.Gender.Equals(s.Gender))
                .Where(x => s.School == null || s.School.Equals("Select School") || x.SchoolName.Equals(s.School))
                .Where(x => s.Lunch==null || x.Lunch == lunchBool)
                .Where(x => s.Income==null || x.Income.Equals(s.Income))
                .Where(x => s.Active==null || x.Active == activeBool)
                .Where(x => s.SchoolGrade==null || x.SchoolGrade.Equals(s.SchoolGrade))
                .Where(x => s.YearsEnrolled == null || year-x.EnrolledYear == int.Parse(s.YearsEnrolled))
                .Where(x => s.Site == null || s.Site.Equals("Select KU Site") || x.Facility.Equals(s.Site))
                .ToArrayAsync();
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






        //REPORT CARD STUFF STARTS HERE

        public async Task<ReportCard[]> GetReportCardsAsync(int Id)
        {
            //returns all report cards for Student
            Student student = await _context.Students.Where(x => x.StudentId == Id).FirstAsync();
            return await _context.ReportCards.Where(x => x.Student == student).ToArrayAsync();
        }

        public async Task<ReportCard> GetReportCardAsync(int Id)
        {
            //returns single report card from report card id
            return await _context.ReportCards.Where(x => x.ReportCardId == Id).Include(r => r.Student).FirstAsync();
        }

        public async Task<bool> SubmitNewReportCardAsync(ReportCard newReportCard)
        {
            //puts new report card in database

            //gets the student the report card is for from the database
            Student student = await _context.Students.Where(x => x.StudentId == newReportCard.Student.StudentId).FirstAsync();

            newReportCard.Student = student;
            await _context.ReportCards.AddAsync(newReportCard);

            //adds report to the student
            student.ReportCards.Add(newReportCard);

            //updates student in database
            _context.Entry(await _context.Students.FirstAsync(x => x.StudentId == student.StudentId)).CurrentValues.SetValues(student);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> ApplyEditReportCardAsync(ReportCard editedReportCard)
        {
            _context.Entry(await _context.ReportCards.FirstAsync(x => x.ReportCardId == editedReportCard.ReportCardId)).CurrentValues.SetValues(editedReportCard);

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
