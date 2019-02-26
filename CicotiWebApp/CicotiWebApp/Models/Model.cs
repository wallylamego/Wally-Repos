using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        [Required]
        [MaxLength(50)]
        public string ModelName { get; set; }
        public int ? NoOfWheels { get; set; }
        public int ? MakeID { get; set; }
        public int ? FuelTypeID { get; set; }
        public int ? DriveTypeID { get; set; }
        public int ? VehicleTypeID { get; set; }

        public Make Make { get; set; }
        public FuelType FuelType { get; set; }
        public DriveType DriveType { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
