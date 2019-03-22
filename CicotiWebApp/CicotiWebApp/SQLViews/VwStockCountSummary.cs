using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class VwStockCountSummary
    {
        public int NoOfCounts { get; private set; }
        public Double Qty { get; private set; }
        public string SKUName { get; private set; }
        public string Quality { get; private set; }
        public string UOM { get; private set; }
        public string PrincipalName { get; private set; }
        public string Code { get; private set; }
    }
}
