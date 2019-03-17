using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class VwDeliveryStatsSummary
    {
        public int OutsideSlaDeliveries { get; private set; }
        public int TotalDeliveries { get; private set; }
        public Double PercentageOutside { get; private set; }
        public Double PercentageInside { get; private set; }
        public string YearMonth { get; private set; }
    }
}
