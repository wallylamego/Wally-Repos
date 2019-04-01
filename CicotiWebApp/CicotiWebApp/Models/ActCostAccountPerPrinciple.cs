using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostAccountPerPrinciple
    {
        public int ActCostAccountPerPrincipleID { get; set; }
        public int ActCostPeriodID { get; set; }
        public int PrincipleID { get; set; }
        public int ActCostAccountID { get; set; }
        public Double AllocAccountPerc { get; set; }
        public string Comments { get; set; }

        public ActCostAccount ActCostAccount { get; set; }
        public Principle Principle { get; set; }
        public ActCostPeriod ActCostPeriod { get; set; }
    }
}
