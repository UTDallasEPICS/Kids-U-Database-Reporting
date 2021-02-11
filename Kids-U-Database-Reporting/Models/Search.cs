using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class Search
    {
        public Search()
        {
            Active = "True"; // Default filter out inactive students
        }
        public string SortOrder { get; set; }
        public int ResultCount { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string SchoolGrade { get; set; }
        public string Lunch { get; set; }
        public string Income { get; set; }
        public string Active { get; set; }
        public string YearsEnrolled { get; set; }
        public string School { get; set; }
        public string Site { get; set; }
        public List<String> SchoolList { get; set; }
        public List<String> SiteList { get; set; }
    }
}
