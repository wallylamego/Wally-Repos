using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostAlloctedSpacePerPrinciple
    {
        public int ActCostAlloctedSpacePerPrincipleID { get; set; }
        public string Comments { get; set; }
        public int ActCostPeriodID { get; set; }
        public int BranchID { get; set; }
        public int PrincipleID { get; set; }
        public double PercentageAllocated { get; set; }
        public double AmtAllocated { get; set; }

        public ActCostPeriod ActCostPeriod { get; set; }
        public Branch Branch {get;set;}
        public Principle Principle { get; set; }

    }
}
