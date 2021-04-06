using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kids_U_Database_Reporting.Models
{
    public class SelectLists
    {
        public List<SelectListItem> SchoolList { get; set; }
        public List<SelectListItem> SiteList { get; set; }

        public List<SelectListItem> EthnicityList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value="", Text="Select Ethnicity" },
            new SelectListItem { Value="African American", Text="African American" },
            new SelectListItem { Value="Asian", Text="Asian" },
            new SelectListItem { Value="Hispanic/Latino", Text="Hispanic/Latino" },
            new SelectListItem { Value="Caucasian", Text= "Caucasian" },
            new SelectListItem { Value="Other", Text="Other" }
        };
        // Old team chose to use the &lt; &gt; and not sure why, might be able to change to < > for better readibility
        public List<SelectListItem> IncomeList { get; }=new List<SelectListItem>
        {
            new SelectListItem { Value="", Text="Select Income" },
            new SelectListItem { Value="&lt; $20k", Text="< $20K" },
            new SelectListItem { Value="$20k - $25k", Text="$20K - $25K" },
            new SelectListItem { Value="&gt; $25k", Text="> $25K" }
        };
        public List<SelectListItem> ActiveList { get; }=new List<SelectListItem>
        {
            new SelectListItem { Value="", Text="Active ?" },
            new SelectListItem { Value="True", Text="Yes" },
            new SelectListItem { Value="False", Text="No" }
        };
        public List<SelectListItem> YearsEnrolledList { get; }=new List<SelectListItem>
        {
            new SelectListItem { Value="", Text="Select Years Enrolled" },
            new SelectListItem { Value="0", Text="< 1" },
            new SelectListItem { Value="1", Text="1" },
            new SelectListItem { Value="2", Text="2" },
            new SelectListItem { Value="3", Text="3" },
            new SelectListItem { Value="4", Text="4" },
            new SelectListItem { Value="5", Text="5" },
            new SelectListItem { Value="6", Text="6" },
            new SelectListItem { Value="7", Text="7" },
            new SelectListItem { Value="8", Text="8" }
        };
        public List<SelectListItem> GenderList { get; }=new List<SelectListItem>
        {
            new SelectListItem { Value="", Text="Select Gender" },
            new SelectListItem { Value="Female", Text="Female" },
            new SelectListItem { Value="Male", Text="Male" }
        };
        public List<SelectListItem> SchoolGradeList { get; }=new List<SelectListItem>
        {
            new SelectListItem { Value="", Text="Select School Grade" },
            new SelectListItem { Value="K", Text="K" },
            new SelectListItem { Value="1", Text="1" },
            new SelectListItem { Value="2", Text="2" },
            new SelectListItem { Value="3", Text="3" },
            new SelectListItem { Value="4", Text="4" },
            new SelectListItem { Value="5", Text="5" },
            new SelectListItem { Value="6", Text="6" },
            new SelectListItem { Value="7", Text="7" },
            new SelectListItem { Value="8", Text="8" }
        };
        public List<SelectListItem> LunchList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value="", Text="Free Lunch?" },
            new SelectListItem { Value="True", Text="Yes" },
            new SelectListItem { Value="False", Text="No" }
        };
        public List<SelectListItem> SemesterList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value="", Text="Select Semester" },
            new SelectListItem { Value="fall", Text="Fall" },
            new SelectListItem { Value="spring", Text="Spring" },
            new SelectListItem { Value="summer", Text="Summer" }
        };
        public List<SelectListItem> SortOrderList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value="0", Text="Sort by..." },
            new SelectListItem { Value="1", Text="First Name A-Z" },
            new SelectListItem { Value="2", Text="First Name Z-A" },
            new SelectListItem { Value="3", Text="Last Name A-Z" },
            new SelectListItem { Value="4", Text="Last Name Z-A" },
            new SelectListItem { Value="5", Text="Active First" },
            new SelectListItem { Value="6", Text="Active Last" },
            new SelectListItem { Value="7", Text="School A-Z" },
            new SelectListItem { Value="8", Text="School Z-A" },
            new SelectListItem { Value="9", Text="Kids-U Site A-Z" },
            new SelectListItem { Value="10", Text="Kids-U Site Z-A" },
            new SelectListItem { Value="11", Text="Grade Ascending" },
            new SelectListItem { Value="12", Text="Grade Descending" }
        };

        public List<SelectListItem> Relationship { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value="", Text="Select relationship" },
            new SelectListItem { Value="Mother", Text="Mother" },
            new SelectListItem { Value="Father", Text="Father" },
            new SelectListItem { Value="Relative", Text="Relative" },
            new SelectListItem { Value="Guardian", Text="Guardian" }
        };
    }
}
