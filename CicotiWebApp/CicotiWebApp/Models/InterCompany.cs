using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class InterCompany
    {
        public int InterCompanyID { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int ActCostPeriodID { get; set; }
        public int ExchangeRateID { get; set; }

        public ExchangeRate ExchangeRate { get; set; }
        public ActCostPeriod GetActCostPeriod { get; set; }

    }
}
