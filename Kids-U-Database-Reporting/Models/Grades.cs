using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class Grades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradesId { get; set; }
        //[ForeignKey("ReportCardId")]
        //public ReportCard ReportCard { get; set; }
        public int? First { get; set; }
        public int? Second { get; set; }
        public int? Third { get; set; }
        public int? Fourth { get; set; }
        public int? Fifth { get; set; }
        public int? Semester { get; set; }
    }
}
