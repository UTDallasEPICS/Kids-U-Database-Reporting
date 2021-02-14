using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public interface ICommonService
    {
        Task<List<String>> GetSiteSelectList();
        Task<List<String>> GetSchoolSelectList();
    }
}
