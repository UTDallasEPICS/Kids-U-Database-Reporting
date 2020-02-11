using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class ReportCard
    {
        public int ReportSchoolGrade { get; set; }
        public OutcomeMeasurement Outcome;
        public Grades LanguageArts;
        public Grades Reading;
        public Grades Math;

    }
}
