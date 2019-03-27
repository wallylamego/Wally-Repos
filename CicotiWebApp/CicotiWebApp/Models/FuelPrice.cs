using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class FuelPrice
    {
        public int FuelPriceID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Double PriceExclVat { get; set; }
        public Double PriceInclVat { get; set; }
    }
}
