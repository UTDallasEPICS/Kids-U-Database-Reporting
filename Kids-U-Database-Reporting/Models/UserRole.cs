using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Models
{
    public class UserRole : IdentityRole
    {
        public UserRole() : base() { }

        public UserRole(string roleName) : base(roleName)
        {

        }

    }
}
