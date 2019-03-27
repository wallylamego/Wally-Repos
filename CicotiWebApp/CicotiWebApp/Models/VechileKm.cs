using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class VehicleKm
    {
        public int VehicleKmID { get; set; }
        public DateTime TravelDate { get; set; }
        public double StartKm { get; set; }
        public double EndKm { get; set; }
        public double TravelKm { get; set; }
        public int ? ActCostPeriodID { get; set; }

        public Vehicle Vehicle { get; set; }
        public ActCostPeriod GetActCostPeriod { get; set; }
    }
}
