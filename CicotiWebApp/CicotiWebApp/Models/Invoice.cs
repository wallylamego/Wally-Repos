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
        public int ? LoadID { get; set;}
        public int? WarehouseID { get; set; }
        public int CustomerAccountID { get; set; }
        public double ? InvoiceAmount { get; set; }
        public int ? InvoiceProductTypeID { get; set; }
        public CustomerAccount CustomerAccount {get;set;}
        public ICollection<InvoiceStatus> InvoiceStatuses { get; set; }
        public double ? Weight { get; set; }
        public double ? CubicMetres { get; set; }


        public Status Status { get; set; }
        public Load Load { get; set; }
        public InvoiceProductType InvoiceProductType { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
