using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class DeliveryStatsDetail
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoicePrintDate { get; set; }
        public int CustomerAccountID{get;set;}
        public string InvoiceNumber { get; set; }
        public string StatusName { get; set; }
        public DateTime LastStatusDate { get; set; }
        public Double ExpiryTime { get; set; }
        public Double TargetExpiryTime { get; set; }
        public string SLAStatus { get; set; }
    }
}
