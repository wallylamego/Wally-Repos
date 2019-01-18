using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class SKU
    {
        public int SKUID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitsPerPallets { get; set; }
        public double CubicMetrePerPallet { get; set; }
        public double CubicMetrePerUnit { get; set; }
        public double WeightPerUnit { get; set; } 
    }
}
