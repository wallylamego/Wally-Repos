using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class VehicleType
    {
        [Key]
        public int VehicleTypeID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
