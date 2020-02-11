using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public interface IStudentService
    {
        //returns array of students
        Task<Student[]> GetIncompleteItemsAsync();
    }
}
