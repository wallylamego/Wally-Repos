using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoicePrintDate { get; set; }
        public int StatusID {get;set;}
        public int CustomerAccountID { get; set; }
        public CustomerAccount CustomerAccount {get;set;}
        public ICollection<InvoiceStatus> InvoiceStatuses { get; set; }

        public Status Status { get; set; }
    }
}
