using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public interface IStudentService
    {
        int GetActiveStudentCount();
        Task<Student> GetStudent(int studentId, string userName);
        Task<Student[]> GetStudents();
        Task<Student[]> GetStudents(Search search, string userName);
        Task<Student[]> GetStudentsWithReportCards(Search searchData, string userName);
        Task<Student[]> GetStudentsWithOutcomes(Search searchData, string userName);
        Task<bool> ApplyEditStudent(Student editedStudent);
        Task<bool> DeleteStudent(int studentId);
        Task<bool> AddStudent(Student newStudent);
    }
}
