using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Price
    {
        public int PriceID { get; set; }
        public DateTime ? PriceDate { get; set; }
        public int ? PriceTypeID { get; set; }
        public int ? RegionID { get; set; }
        public int ? BranchID { get; set; }
        public int SKUID { get; set; }
        public double PriceExlcVat { get; set; }
        public double PriceInclVat { get; set; }

        public SKU SKU { get; set; }
        public PriceType PriceType { get; set; }
        public Region Region { get; set; }
        public Branch Branch { get; set; }
    }
}
