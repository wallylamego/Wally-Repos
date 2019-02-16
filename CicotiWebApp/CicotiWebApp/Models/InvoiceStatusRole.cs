using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    //This class contains a list of all statuses which a particular role 
    //can authorise
    public class InvoiceStatusRole
    {
        public int InvoiceStatusRoleID { get; set; }
        public string RoleID { get; set; }
        public int StatusID { get; set; }

        public Status Status { get; set; }
        public IdentityRole Role { get; set; }
    }
}
