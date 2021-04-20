using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class OutcomeMeasurementService : IOutcomeMeasurementService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private const string adminRole = "Global Administrator"; // adminRole is able to see students from all sites

        public OutcomeMeasurementService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            //new instance of service is made during each request (required for talking to database) aka scoped lifecycle
            _context = context;
            _userManager = userManager;
        }

        // Returns single Outcome Measurement using Outcome Measurement id
        public async Task<OutcomeMeasurement> GetOutcome(int outcomeId)
        {
            return await _context.OutcomeMeasurements
                .Where(x => x.OutcomeId == outcomeId)
                .Include(r => r.Student)
                .FirstAsync();
        }

        // Returns all Outcome Measurements for a Student
        public async Task<OutcomeMeasurement[]> GetOutcomes(int studentId, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName); // Get the current user from userName
            return await _context.OutcomeMeasurements
                .Where(x => user.Role == adminRole || x.Student.Facility.Equals(user.Site)) // Check that user is admin or student is at the user's site
                .Where(x => x.Student.StudentId == studentId).ToArrayAsync();
        }

        // Returns all Outcome Measurements for a Student with the Student data included
        public async Task<OutcomeMeasurement[]> GetOutcomesWithStudent(int studentId, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName); // Get the current user from userName
            return await _context.OutcomeMeasurements
                .Include(s => s.Student)
                .Where(x => user.Role == adminRole || x.Student.Facility.Equals(user.Site)) // Check that user is admin or student is at the user's site
                .Where(x => x.Student.StudentId == studentId)
                .ToArrayAsync();
        }

        // Gets all Outcome Measurements that matches the search filters with Student data included
        public async Task<OutcomeMeasurement[]> GetAllOutcomes(Search s, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName); // Get the current user from userName
            var outcomes = _context.OutcomeMeasurements
                .Include(s => s.Student) // .Include() loads the Student, otherwise it is just a reference without the actual data
                .Where(x => user.Role == adminRole || x.Student.Facility.Equals(user.Site)); // Check that user is admin or student is at the user's site

            outcomes = FilterAndSort(s, outcomes);

            return await outcomes.ToArrayAsync();
        }

        // Puts new Outcome Measurement in database
        public async Task<bool> SubmitNewOutcome(OutcomeMeasurement newOutcomeMeasurement)
        {

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

        public async Task<bool> ApplyEditOutcome(OutcomeMeasurement editedOutcomeMeasurement)
        {
            _context.Entry(await _context.OutcomeMeasurements.FirstAsync(x => x.OutcomeId == editedOutcomeMeasurement.OutcomeId)).CurrentValues.SetValues(editedOutcomeMeasurement);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        // Deletes Outcome Measurement in database by id
        public async Task<bool> DeleteOutcome(int outcomeId)
        {
            OutcomeMeasurement outcome = await _context.OutcomeMeasurements.Where(x => x.OutcomeId == outcomeId).FirstAsync();
            _context.OutcomeMeasurements.Remove(outcome);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        // Apply search filters and sorting to a list of outcomes
        private IQueryable<OutcomeMeasurement> FilterAndSort(Search s, IQueryable<OutcomeMeasurement> outcomes)
        {
            // Convert string from search form to bool used in database
            bool lunchBool = s.Lunch == "True";
            bool activeBool = s.Active == "True";
            int year = DateTime.Now.Year;

            outcomes = outcomes
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
                case "1": outcomes = outcomes.OrderBy(s => s.Student.FirstName); break;
                case "2": outcomes = outcomes.OrderByDescending(s => s.Student.FirstName); break;
                case "3": outcomes = outcomes.OrderBy(s => s.Student.LastName); break;
                case "4": outcomes = outcomes.OrderByDescending(s => s.Student.LastName); break;
                case "5": outcomes = outcomes.OrderByDescending(s => s.Student.Active); break; // Active ("True") first
                case "6": outcomes = outcomes.OrderBy(s => s.Student.Active); break; // Inactive ("False") first
                case "7": outcomes = outcomes.OrderBy(s => s.Student.SchoolName); break;
                case "8": outcomes = outcomes.OrderByDescending(s => s.Student.SchoolName); break;
                case "9": outcomes = outcomes.OrderBy(s => s.Student.Facility); break;
                case "10": outcomes = outcomes.OrderByDescending(s => s.Student.Facility); break;
                case "11": outcomes = outcomes.OrderBy(s => s.Student.SchoolGrade); break;
                case "12": outcomes = outcomes.OrderByDescending(s => s.Student.SchoolGrade); break;
            }
            return outcomes;
        }
    }
}
