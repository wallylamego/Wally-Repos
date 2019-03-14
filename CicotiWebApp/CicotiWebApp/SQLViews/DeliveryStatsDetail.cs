using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class VwDeliveryStatusDetail
    {
        public int InvoiceID { get; private set; }
        public string InvoiceNumber { get; private set; }
        public DateTime InvoiceDate { get; private set; }
        public DateTime InvoicePrintDate { get; private set; }
        public int CustomerAccountID{get; private set; }
        public string StatusName { get; private set; }
        public DateTime LastStatusDate { get; private set; }
        public int ExpiryTime { get; private set; }
        public Double TargetExpiryTime { get; private set; }
        public string SLAStatus { get; private set; }
        public int StatusID { get; private set; }
    }
}
