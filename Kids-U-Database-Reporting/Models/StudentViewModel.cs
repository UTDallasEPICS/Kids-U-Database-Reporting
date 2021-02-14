using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class StudentViewModel
    {
        public Student[] Students { get; set; }
        public Search SearchData { get; set; }
        public SelectLists SelectLists { get; set; }
    }
}
