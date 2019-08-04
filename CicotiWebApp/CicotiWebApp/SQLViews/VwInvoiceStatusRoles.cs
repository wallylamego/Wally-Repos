using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class VwInvoiceStatusRoles
    {
        public string RoleName { get; set; }
        public string RoleID { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public int SortOrder { get; set; }
    }
}
