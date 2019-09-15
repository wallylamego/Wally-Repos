using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Price
    {
        public int PriceID { get; set; }
        public int PriceTypeID { get; set; }
        public int SKUID { get; set; }
        public double PriceExVat { get; set; }
        public double PriceInclVat { get; set; }

        public SKU SKU { get; set; }
        public PriceType PriceType { get; set; }
    }
}
