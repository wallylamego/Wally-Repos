using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostAccountAmtPrinciple
    {
        public int ActCostAccountAmtPrincipleID { get; set; }
        public int PrincipleID { get; set; }
        public int ActCostPeriodID { get; set; }
        public int ActCostAccountID { get; set; }
        public double Amount { get; set; }
        public string Comments { get; set; }

        public ActCostPeriod ActCostPeriod { get; set; }
        public ActCostAccount GetActCostAccount { get; set; }
        public Principle Principle { get; set; }

}
}
