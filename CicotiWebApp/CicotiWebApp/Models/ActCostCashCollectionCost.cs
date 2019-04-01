using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostCashCollectionCost
    {
        public int ActCostCashCollectionCostID { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double InsuredAssetAmt { get; set; }
        public int BranchID { get; set; }
        public int ActCostPeriodID { get; set; }

        public Branch Branch { get; set; }
        public ActCostPeriod ActCostPeriod { get; set; }
    }
}
