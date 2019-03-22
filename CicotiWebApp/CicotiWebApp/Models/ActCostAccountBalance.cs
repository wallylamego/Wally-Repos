using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostAccountBalance
    {
        public Int32 ActCostAccountBalanceID { get; set; }
        public int AccountID{get;set;}
        public int PeriodID { get; set; }
        public double YTD { get; set; }
        public double Movement { get; set; }
    }
}
