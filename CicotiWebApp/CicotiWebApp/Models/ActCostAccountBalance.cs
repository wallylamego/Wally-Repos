using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostAccountBalance
    {
        public Int32 ActCostAccountBalanceID { get; set; }
        public int ? ActCostAccountID { get;set;}
        public int ActCostPeriodID { get; set; }
        public double YTD { get; set; }
        public double Movement { get; set; }

        public ActCostPeriod ActCostPeriod { get; set; }
        public ActCostAccount ActCostAccount { get; set; }
    }
}
