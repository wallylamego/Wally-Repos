using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public int VehicleTypeID { get; set; }
        public int SubContractorID { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        public VehicleType VechileType { get; set; }
        public SubContractor SubContractor { get; set; }
    }
}
