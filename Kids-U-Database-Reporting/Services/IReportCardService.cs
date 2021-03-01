using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public interface IReportCardService
    {
        Task<ReportCard[]> GetReportCardsAsync(int studentId);
        Task<ReportCard[]> GetReportCardsWithStudentAsync(int studentId);
        Task<ReportCard[]> GetAllReportCardsAsync(Search searchData);
        Task<ReportCard> GetReportCardAsync(int Id);
        Task<bool> SubmitNewReportCardAsync(ReportCard newReportCard);
        Task<bool> ApplyEditReportCardAsync(ReportCard editedReportCard);
    }
}
