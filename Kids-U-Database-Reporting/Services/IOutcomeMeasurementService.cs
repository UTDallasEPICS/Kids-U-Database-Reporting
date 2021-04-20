using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public interface IOutcomeMeasurementService
    {
        Task<OutcomeMeasurement> GetOutcome(int outcomeId);
        Task<OutcomeMeasurement[]> GetOutcomes(int studentId, string userName);
        Task<OutcomeMeasurement[]> GetOutcomesWithStudent(int studentId, string userName);
        Task<OutcomeMeasurement[]> GetAllOutcomes(Search s, string userName);
        Task<bool> SubmitNewOutcome(OutcomeMeasurement newOutcomeMeasurement);
        Task<bool> ApplyEditOutcome(OutcomeMeasurement editedOutcomeMeasurement);
        Task<bool> DeleteOutcome(int outcomeId);
    }
}
