using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostTransaction
    {
        public Int32 ActCostTransactionID { get; set; }
        public int BranchID { get; set; }
        public int ActCostDriverID { get; set; }
        public int ActCostPeriodID { get; set; }
        public int PrincipleID { get; set; }
        public int ActCostAllocationSplitID { get; set; }
        
        public Int32 Qty { get; set; }
        public Double Amount { get; set; }
        public double QtyPercAllocation { get; set; }
        public double AmtPercAllocation { get; set; }

        public ActCostPeriod ActCostPeriod { get; set; }
        public ActCostAllocationSplit ActCostAllocatoionSplit { get; set; }
        public ActCostDriver ActCostDriver { get; set; }
        public Principle Principle { get; set; }

    }
}
