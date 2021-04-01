using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public interface IReportCardService
    {
        Task<ReportCard[]> GetReportCards(int studentId);
        Task<ReportCard[]> GetReportCardsWithStudent(int studentId);
        Task<ReportCard[]> GetAllReportCards(Search searchData);
        Task<ReportCard> GetReportCard(int reportId);
        Task<bool> SubmitNewReportCard(ReportCard newReportCard);
        Task<bool> ApplyEditReportCard(ReportCard editedReportCard);
        Task<bool> DeleteReport(int reportId);
    }
}
