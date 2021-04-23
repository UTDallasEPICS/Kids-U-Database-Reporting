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
        public char? SchoolGrade { get; set; }
        public string Lunch { get; set; }
        public string Income { get; set; }
        public string Active { get; set; }
        public string YearsEnrolled { get; set; }
        public string School { get; set; }
        public string Site { get; set; }
    }
}