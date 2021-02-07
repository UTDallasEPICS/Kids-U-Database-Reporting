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
        public string SearchName { get; set; }
        public string SelectedGender { get; set; }
        public string SelectedEthnicity { get; set; }
        public string SelectedSchoolGrade { get; set; }
        public string SelectedLunch { get; set; }
        public string SelectedIncome { get; set; }
        public string SelectedActive { get; set; }
        public string SelectedYearsEnrolled { get; set; }
        public string SelectedSchool { get; set; }
        public string SelectedSite { get; set; }
        public List<String> SchoolList { get; set; }
        public List<String> SiteList { get; set; }
    }
}
