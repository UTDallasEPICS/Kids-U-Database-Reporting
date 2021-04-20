using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public interface IReportCardService
    {
        Task<ReportCard> GetReportCard(int reportId);
        Task<ReportCard[]> GetReportCards(int studentId, string userName);
        Task<ReportCard[]> GetReportCardsWithStudent(int studentId, string userName);
        Task<ReportCard[]> GetAllReportCards(Search searchData, string userName);
        Task<bool> SubmitNewReportCard(ReportCard newReportCard);
        Task<bool> ApplyEditReportCard(ReportCard editedReportCard);
        Task<bool> DeleteReport(int reportId);
    }
}
