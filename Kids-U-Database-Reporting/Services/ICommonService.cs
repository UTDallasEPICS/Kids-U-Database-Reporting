using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kids_U_Database_Reporting.Services
{
    public interface ICommonService
    {
        Task<List<object>> GetStudentNameList(string userName);
        Task<List<SelectListItem>> GetSiteSelectList();
        Task<List<SelectListItem>> GetSchoolSelectList();
    }
}
