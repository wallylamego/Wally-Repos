using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class SKU
    {
        public int SKUID { get; set; }
        [DisplayName("Stock Code Per ERP System")]
        public string Code { get; set; }
        public string Description { get; set; }
        [DisplayName("UOM")]
        public string UOM { get; set; }
        [DisplayName("UOM Conversion Factor")]
        public string UOMConversionFactor { get; set; }
        [DisplayName("Units Per Pallet")]
        public double UnitsPerPallets { get; set; }
        [DisplayName("Cubic Metres Per Pallet")]
        public double CubicMetrePerPallet { get; set; }
        [DisplayName("Cubic Metres Per Unit")]
        public double CubicMetrePerUnit { get; set; }
        [DisplayName("Weight in Kgs Per Unit")]
        public double WeightPerUnit { get; set; }
    }
}
