using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class ReportCard
    {
       
        public int ReportCardId { get; set; }
        public int ReportSchoolGrade { get; set; }
        
        public string ReportSchoolSemester { get; set; }
        public OutcomeMeasurement Outcome { get; set; }
        public Grades LanguageArts { get; set; }
       // public Grades Reading { get; set; }
        //public Grades Math { get; set; }

        //Reference navigation property having a multiplicity of zero or one

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        
        

    }
}
