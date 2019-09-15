using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class VwInvoiceWeightsDetail
    {
        public string AccountNumber { get; set; }
        public string AccountDescription { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoicePrintDate { get; set; }
        public string InvoiceNumber { get; set; }
        public Double InvoiceAmount { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public Double CubicMetrePerUnit { get; set; }
        public Double WeightPerUnit { get; set; }
        public Double Qty { get; set; }
        public Double CM { get; set; }
        public Double Kgs { get; set; }
        public Double Amt { get; set; }
        public int StatusID { get; set; }

    }
}
