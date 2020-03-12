using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser() : base() { }

       
        public string FirstName { get; set; }

        public string LastName { get; set; }

      
        public string Site { get; set; }

    
        public bool Active { get; set; }

        public string Role { get; set; }


    }
}
