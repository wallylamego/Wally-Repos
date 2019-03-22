using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostAccount
    {
        public int ActCostAccountID{get;set;}
        public string AccountNo { get; set; }
        public int BranchID { get; set; }
        public string Description { get; set; }
        public int ActCostCategoryID { get; set; }

        public Branch Branch { get; set; }
        public ActCostCategory ActCostCategory { get; set; }
    }
}
