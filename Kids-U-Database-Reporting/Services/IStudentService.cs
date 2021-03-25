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
        Task<Student[]> GetStudentsWithOutcomes(Search searchData);
        Task<Student> GetStudentById(int studentId);
        Task<bool> ApplyEditStudent(Student editedStudent);
        Task<bool> DeleteStudent(int studentId);
        Task<bool> AddStudent(Student newStudent);
    }
}
