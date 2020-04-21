using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class SchoolWithDistrictViewModel
    {
        public School Schools {get;set;}
        public District [] Districts { get; set; }
        
    }
}
