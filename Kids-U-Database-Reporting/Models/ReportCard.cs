using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class ReportCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportCardId { get; set; }
        public char ReportSchoolGrade { get; set; }
        public string ReportSchoolSemester { get; set; }
        public OutcomeMeasurement Outcome { get; set; }
        public LanguageArts LanguageArts { get; set; }
        public Reading Reading { get; set; }
        public Math Math { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

    }
}
