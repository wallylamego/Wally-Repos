using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostInsuranceType
    {
        public int ActCostInsuranceTypeID {get;set;}
        public string Description { get; set; }
        public int ActCostDriverID { get; set; }
        public int ActCostPeriodID { get; set; }
        public double Amount { get; set; }

        public ActCostDriver ActCostDriver { get; set; }
        public ActCostPeriod ActCostPeriod { get; set; }

    }
}
