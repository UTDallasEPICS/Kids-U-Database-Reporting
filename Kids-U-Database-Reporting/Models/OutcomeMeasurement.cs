using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class OutcomeMeasurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OutcomeId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public string ReportSchoolGrade { get; set; }
        public string ReportSchoolSemester { get; set; }
        public string MathPreTest { get; set; }
        public string MathPostTest { get; set; }
        public string LanguagePreTest { get; set; }
        public string LanguagePostTest { get; set; }
        public string ReadingPreTest { get; set; }
        public string ReadingFluencyTest { get; set; }
        public string ReadingFluencyTest2 { get; set; }
        public string ReadingFluencyTest3 { get; set; }
        public string SelfEsteemPreTest { get; set; }
        public string SelfEsteemPostTest { get; set; }


    }
}
