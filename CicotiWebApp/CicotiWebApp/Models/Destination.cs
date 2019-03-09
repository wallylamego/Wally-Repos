﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Destination
    {
        public int DestinationID { get; set; }
        [Required]
        public int StartLocationID { get; set; }
        [Required]
        public int EndLocationID { get; set; }
        [Required]
        public double Distance { get; set; }

        /*Navigation Properties*/
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }        
    }
}
