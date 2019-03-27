using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostBalanceAllocation
    {
        public Int32 ActCostBalanceAllocationID { get; set; }
        public int ActCostDriverID { get; set; }
        public int ActCostAccountID { get; set; }
        public int ActCostPeriodID { get; set; }
        public int PrincipleID {get;set;}
        public Int32 ActCostAccountBalanceID { get; set; }
        public int ActCostAllocationSplitID { get; set; }
        public double AccountCost { get; set; }
        public double AllocAccountCost { get; set; }


        public ActCostAccount ActCostAccount { get; set; }
        public ActCostDriver ActCostDriver { get; set; }
        public ActCostPeriod ActCostPeriod { get; set; }
        public Principle Principle { get; set; }
        public ActCostAllocationSplit ActCostAllocationSplit { get; set; }
        public ActCostAccountBalance ActCostAccountBalance { get; set; }
}
}
