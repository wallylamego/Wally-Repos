using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class VwInvoiceWeightSummary
    {
      public string AccountDescription { get; set; }
      public string AccountNumber { get; set; }
      public DateTime InvoiceDate { get; set; }
      public string InvoiceNumber { get; set; }
      public DateTime InvoicePrintDate { get; set; }
      public string StatusName { get; set; }
      public double CM { get; set; }
      public double Kgs { get; set; }
      public double Amt { get; set; }
      public int StatusID { get; set; }
    }
}
