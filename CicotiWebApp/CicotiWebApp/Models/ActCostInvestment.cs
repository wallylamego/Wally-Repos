using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostInvestment
    {
        public int ActCostInvestmentID { get; set; }
        public int ActCostInvestmentTypeID { get; set; }
        public int PrincipleID { get; set; }
        public int ActCostPeriodID { get; set; }

        public Double Amount { get; set; }

        public ActCostInvestmentType ActCostInvestmentType { get; set; }
        public ActCostPeriod ActCostPeriod { get; set; }
        public Principle Principle { get; set; }
    }
}
