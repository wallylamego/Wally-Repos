using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostPrincipleBalance
    {
        public int ActCostPrincipleBalanceID { get; set; }
        public int PrincipleID { get; set; }
        public int ActCostPeriodID { get; set; }
        public double Balance { get; set; }

        public Principle Principle { get; set; }
        public ActCostPeriod ActCostPeriod { get; set; }

    }
}
