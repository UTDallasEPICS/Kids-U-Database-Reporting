using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class OutcomeMeasurementService : IOutcomeMeasurementService
    {
        private readonly ApplicationDbContext _context;

        public OutcomeMeasurementService(ApplicationDbContext context)
        {
            //new instance of service is made during each request (required for talking to database) aka scoped lifecycle
            _context = context;
        }

        public async Task<OutcomeMeasurement[]> GetOutcomes(int Id)
        {
            //returns all outcome measurements for a Student
            Student student = await _context.Students.Where(x => x.StudentId == Id).FirstAsync();
            return await _context.OutcomeMeasurements.Where(x => x.Student == student).ToArrayAsync();
        }

        public async Task<OutcomeMeasurement> GetOutcome(int Id)
        {
            //returns single outcome measurement from outcome measurement id
            return await _context.OutcomeMeasurements.Where(x => x.OutcomeId == Id).Include(r => r.Student).FirstAsync();
        }

        public async Task<bool> SubmitNewOutcome(OutcomeMeasurement newOutcomeMeasurement)
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

        public async Task<bool> ApplyEditOutcome(OutcomeMeasurement editedOutcomeMeasurement)
        {
            _context.Entry(await _context.OutcomeMeasurements.FirstAsync(x => x.OutcomeId == editedOutcomeMeasurement.OutcomeId)).CurrentValues.SetValues(editedOutcomeMeasurement);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
