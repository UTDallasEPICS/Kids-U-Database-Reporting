using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class OutcomeViewModel
    {
        public Student Student;
        public OutcomeMeasurement[] OutcomeMeasurements { get; set; }
    }
}
