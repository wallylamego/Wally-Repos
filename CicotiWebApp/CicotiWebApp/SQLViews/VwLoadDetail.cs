using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class VwLoadDetail
    {
        public int LoadID { get; set; }
        public string LoadName { get; set; }
        public DateTime LoadDate { get; set; }
        public string LoadStatus { get; set; }
        public string SubName { get; set; }
        public string RegistrationNumber { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverSurname { get; set; }
        public string VehicleType { get; set; }
        public string ModelName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceAmount { get; set; }
        public string AccountNumber { get; set; }
        public string AccountDescription { get; set; }
    }
}
