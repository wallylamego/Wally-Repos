using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ExchangeRate
    {
        public int ExchangeRateID { get; set; }
        public int FirstCurrencyID { get; set; }
        public int SecondCurrencyID { get; set; }
        public int ActCostPeriodID { get; set; }
        public string Description { get; set; }

        public double AverageRate { get; set; }
        public double ClosingRate { get; set; }

        public ActCostPeriod ActCostPeriod { get; set; }

        [ForeignKey(nameof(FirstCurrencyID))]
        public Currency FirstCurrency { get; set; }

        [ForeignKey(nameof(SecondCurrencyID))]
        public Currency SecondCurrency { get; set; }

    }
}
