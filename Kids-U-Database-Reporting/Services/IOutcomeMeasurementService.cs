using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kids_U_Database_Reporting.Models;

namespace Kids_U_Database_Reporting.Services
{
    public interface IOutcomeMeasurementService
    {
        Task<OutcomeMeasurement[]> GetOutcomes(int Id);
        Task<OutcomeMeasurement> GetOutcome(int Id);
        Task<bool> SubmitNewOutcome(OutcomeMeasurement newOutcomeMeasurement);
        Task<bool> ApplyEditOutcome(OutcomeMeasurement editedOutcomeMeasurement);
    }
}
