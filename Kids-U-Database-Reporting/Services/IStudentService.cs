using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public interface IStudentService
    {
        //student CRUD operations
        Task<Student[]> GetStudents();
        Task<Student[]> GetStudents(Search search);
        Task<Student[]> GetStudentsWithReportCards(Search searchData);
        Task<Student[]> GetStudentsWithOutcomeMeasurements(Search searchData);
        Task<Student> GetStudentById(int Id);
        Task<Student> EditStudent(int Id);
        Task<bool> ApplyEditStudent(Student editedStudent);
        Task<bool> DeleteStudent(int Id);
        Task<bool> AddStudent(Student newStudent);


        //outcome measurement CRUD operations
        Task<OutcomeMeasurement[]> GetOutcomes(int Id);
        Task<OutcomeMeasurement> GetOutcome(int Id);
        Task<bool> SubmitNewOutcome(OutcomeMeasurement newOutcomeMeasurement);
        Task<bool> ApplyEditOutcome(OutcomeMeasurement editedOutcomeMeasurement);
    }
}
