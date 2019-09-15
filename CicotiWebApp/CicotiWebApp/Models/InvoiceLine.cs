using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class InvoiceLine
    {
        public long InvoiceLineID { get; set; }
        public int SKUID { get; set; }
        public int InvoiceID { get; set; }
        public double Qty { get; set; }
        public double Amt { get; set; }
        public double? Weight { get; set; }
        public double? CubicMetres { get; set; }

        public Invoice Invoice { get; set; }
        public SKU SKU { get; set; }
        
    }
}
