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
        public int MainAccountNo { get; set; }
        public int BranchID { get; set; }
        public string Description { get; set; }
        public int ActCostCategoryID { get; set; }
        public int ? ActCostSubCategoryID { get; set; }
        public int ? ActCostDriverID { get; set; }
        public int ? ActCostAllocationSplitID { get; set; }
        public int ? ActCostAccountTypeID { get; set; }

        public Branch Branch { get; set; }
        public ActCostCategory ActCostCategory { get; set; }
        public ActCostDriver ActCostDriver { get; set; }
        public ActCostAllocationSplit ActCostAllocationSplit { get; set; }
        public ActCostSubCategory ActCostSubCategory { get; set; }
        public ActCostAccountType ActCostAccountType { get; set; }

    }
}
