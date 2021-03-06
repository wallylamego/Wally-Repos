﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Price
    {
        public int PriceID { get; set; }
        public DateTime ? PriceDate { get; set; }
        public int ? PriceTypeID { get; set; }
        public int ? RegionID { get; set; }
        public int ? BranchID { get; set; }
        public int SKUID { get; set; }
        [DisplayName("Price Excluding Vat")]
        public double PriceExlcVat { get; set; }
        [DisplayName("Price Including Vat")]
        public double PriceInclVat { get; set; }

        public SKU SKU { get; set; }
        [DisplayName("Type of Price")]
        public PriceType PriceType { get; set; }
        public Region Region { get; set; }
        public Branch Branch { get; set; }
    }
}
