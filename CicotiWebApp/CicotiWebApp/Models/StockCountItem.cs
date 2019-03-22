using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class StockCountItem
    {
        public int StockCountItemID { get; set; }
        public int SKUID { get; set; }
        public int UOMID { get; set; }
        public int ? StockQualityID { get; set; }
        public Double Qty { get; set; }
        public String Comments { get; set; }
        public SKU SKU { get; set; }
        public UOM UOM {get;set;}
        public StockQuality StockQuality { get; set; }
    }
}
