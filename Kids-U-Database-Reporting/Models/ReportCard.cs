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

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public string ReportSchoolGrade { get; set; }
        public string ReportSchoolSemester { get; set; }



        public string MathFirst { get; set; }
        public string MathSecond { get; set; }
        public string MathThird { get; set; }
        public string MathFourth { get; set; }
        public string MathFifth { get; set; }
        public string MathSemester { get; set; }


        public string ReadingFirst { get; set; }
        public string ReadingSecond { get; set; }
        public string ReadingThird { get; set; }
        public string ReadingFourth { get; set; }
        public string ReadingFifth { get; set; }
        public string ReadingSemester { get; set; }


        public string LanguageFirst { get; set; }
        public string LanguageSecond { get; set; }
        public string LanguageThird { get; set; }
        public string LanguageFourth { get; set; }
        public string LanguageFifth { get; set; }
        public string LanguageSemester { get; set; }

    }
}
