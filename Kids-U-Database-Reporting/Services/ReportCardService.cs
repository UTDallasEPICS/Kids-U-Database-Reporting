using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class ReportCardService : IReportCardService
    {
        private readonly ApplicationDbContext _context;

        public ReportCardService(ApplicationDbContext context)
        {
            //new instance of service is made during each request (required for talking to database) aka scoped lifecycle
            _context = context;
        }

        // Returns all Report Cards for a Student using StudentId
        public async Task<ReportCard[]> GetReportCards(int studentId)
        {
            return await _context.ReportCards.Where(x => x.Student.StudentId == studentId).ToArrayAsync();
        }
        
        // Returns all Report Cards for a Student using StudentId with Student data included
        public async Task<ReportCard[]> GetReportCardsWithStudent(int studentId)
        {
            return await _context.ReportCards.Include(s => s.Student).Where(x => x.Student.StudentId == studentId).ToArrayAsync();
        }

        // Gets all Report Cards with Student data included that matches the search filters
        public async Task<ReportCard[]> GetAllReportCards(Search s) 
        {
            // Convert string from search form to bool used in database. Needed since the string is tested to be null for no input and bool can't be null
            bool lunchBool = s.Lunch == "True";
            bool activeBool = s.Active == "True";
            int year = DateTime.Now.Year;

            var reports = _context.ReportCards
                .Include(s => s.Student) // .Include() loads the Student, otherwise it is just a reference without the actual data
                .Where(x => s.Name == null || x.Student.FirstName.Contains(s.Name) || x.Student.LastName.Contains(s.Name))
                .Where(x => s.Ethnicity == null || x.Student.Ethnicity.Equals(s.Ethnicity))
                .Where(x => s.Gender == null || x.Student.Gender.Equals(s.Gender))
                .Where(x => s.School == null || s.School.Equals("Select School") || x.Student.SchoolName.Equals(s.School))
                .Where(x => s.Lunch == null || x.Student.Lunch == lunchBool)
                .Where(x => s.Income == null || x.Student.Income.Equals(s.Income))
                .Where(x => s.Active == null || x.Student.Active == activeBool)
                .Where(x => s.SchoolGrade == null || x.Student.SchoolGrade.Equals(s.SchoolGrade))
                .Where(x => s.YearsEnrolled == null || year - x.Student.EnrolledYear == int.Parse(s.YearsEnrolled))
                .Where(x => s.Site == null || s.Site.Equals("Select KU Site") || x.Student.Facility.Equals(s.Site));

            switch (s.SortOrder)
            {
                case "0": break; // Default is no sorting applied
                case "1": reports = reports.OrderBy(s => s.Student.FirstName); break;
                case "2": reports = reports.OrderByDescending(s => s.Student.FirstName); break;
                case "3": reports = reports.OrderBy(s => s.Student.LastName); break;
                case "4": reports = reports.OrderByDescending(s => s.Student.LastName); break;
                case "5": reports = reports.OrderByDescending(s => s.Student.Active); break; // Active ("True") first
                case "6": reports = reports.OrderBy(s => s.Student.Active); break; // Inactive ("False") first
                case "7": reports = reports.OrderBy(s => s.Student.SchoolName); break;
                case "8": reports = reports.OrderByDescending(s => s.Student.SchoolName); break;
                case "9": reports = reports.OrderBy(s => s.Student.Facility); break;
                case "10": reports = reports.OrderByDescending(s => s.Student.Facility); break;
                case "11": reports = reports.OrderBy(s => s.Student.SchoolGrade); break;
                case "12": reports = reports.OrderByDescending(s => s.Student.SchoolGrade); break;
            }

            return await reports.ToArrayAsync();
        }

        // Returns single Report Card using ReportCardId
        public async Task<ReportCard> GetReportCard(int reportId)
        {
            return await _context.ReportCards.Where(x => x.ReportCardId == reportId).Include(r => r.Student).FirstAsync();
        }

        public async Task<bool> SubmitNewReportCard(ReportCard newReportCard)
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

        public async Task<bool> ApplyEditReportCard(ReportCard editedReportCard)
        {
            _context.Entry(await _context.ReportCards.FirstAsync(x => x.ReportCardId == editedReportCard.ReportCardId)).CurrentValues.SetValues(editedReportCard);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        // Deletes Report Card in database by id
        public async Task<bool> DeleteReport(int reportId)
        {
            ReportCard outcome = await _context.ReportCards.Where(x => x.ReportCardId == reportId).FirstAsync();
            _context.ReportCards.Remove(outcome);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
