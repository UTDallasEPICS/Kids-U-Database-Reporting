using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class ReportCard
    {
        public int ReportCardId { get; set; }
        public int ReportSchoolGrade { get; set; }
        public OutcomeMeasurement Outcome { get; set; }
        public Grades LanguageArts { get; set; }
        public Grades Reading { get; set; }
        public Grades Math { get; set; }

        //Reference navigation property having a multiplicity of zero or one
        public Student Student { get; set; }
        //foreign key property
        public Guid StudentId { get; set; }

    }
}
