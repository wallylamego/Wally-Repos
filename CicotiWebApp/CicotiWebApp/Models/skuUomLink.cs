using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class SkuUomLink
    {
        public int SkuUomLinkID { get; set; }
        public string Description { get; set; }
        public int FromUOMID { get; set; }
        public int ToUOMID { get; set; }
        public int SKUID { get; set; }
        public double ConversionFactor { get; set; }

        [ForeignKey(nameof(FromUOMID))]
        public UOM FromUOM { get; set; }
        [ForeignKey(nameof(ToUOMID))]
        public UOM ToUOM { get; set; }
        public SKU SKU { get; set; }
    }
}
