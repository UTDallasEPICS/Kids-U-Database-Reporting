using Kids_U_Database_Reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public interface ISchoolService
    {

        Task<School[]> GetSchoolsAsync();

        Task<School> EditSchoolAsync(int Id);

        Task<bool> DeleteSchoolAsync(int Id);

        Task<bool> AddSchoolAsync(School newStudent);

        Task<bool> ApplyEditStudentAsync(School editedSchool);
    }
}
