﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class UOM
    {
        public int UOMID { get; set; }
        public string Description { get; set; }
        public double ConversionFactor { get; set; }
    }
}
