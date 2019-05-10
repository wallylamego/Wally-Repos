using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class SalesRepCodeEmployeeNoLink
    {
        public int SalesRepCodeEmployeeNoLinkID { get; set; }
        public int EmployeeID { get; set; }
        
        public int SalesRepID { get; set; }

        public Employee Employee { get; set; }
        public SalesRep SalesRep { get; set; }
    }
}
