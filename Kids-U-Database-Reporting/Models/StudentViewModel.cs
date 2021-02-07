using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class StudentViewModel
    {
        public Student[] Students { get; set; }
        public int ResultCount { get; set; }
        public string SelectedEthnicity { get; set; }
        public string SearchName { get; set; }
    }
}
