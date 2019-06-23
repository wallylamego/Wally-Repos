using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class VwEmployeeViewSalesRepCode
    {
        public string EmployeeNo { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CostCentre { get; private set; }
        public string JobDescription { get; private set; }
        public string DepartmentName { get; private set; }
        public string ReportsNoEmployeeNo { get; private set; }
        public string ReportToFirstName { get; private set; }
        public string ReprtsToLastName { get; private set; }
        public string Branch { get; private set; }
        public string SalesRepCode { get; private set; }
        public string SalesRepName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string EmployeeStatus { get; private set; }
        public int EmployeeID { get; private set; }
     }
}
