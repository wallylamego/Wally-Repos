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

        public int ? PrincipleID {get; set;}

        [DisplayName("Stock Code Per ERP System")]
        public string Code { get; set; }
        public string Description { get; set; }

        public string PrincipleDescription { get; set; }

        [DisplayName("Brand")]
        public int? BrandID { get; set; }

        [DisplayName("UOM")]
        public int? UOMID { get; set; }

        [DisplayName("Vat Status")]
        public int VatID { get; set; }

        [DisplayName("Units Per Pallet")]
        public double UnitsPerPallets { get; set; }
        [DisplayName("Cubic Metres Per Pallet")]
        public double CubicMetrePerPallet { get; set; }
        [DisplayName("Cubic Metres Per Unit")]
        public double CubicMetrePerUnit { get; set; }
        [DisplayName("Weight in Kgs Per Unit")]
        public double WeightPerUnit { get; set; }

        public string PrincipalABC { get; set; }
        public string SiloABC { get; set; }
        public string CompanyABC { get; set; }


        public Brand Brand { get; set; }

        public String Comments { get; set; }
        public Principle Principle { get; set; }
        public UOM UOM { get; set; }
        public Vat Vat { get; set; }
    }
}
