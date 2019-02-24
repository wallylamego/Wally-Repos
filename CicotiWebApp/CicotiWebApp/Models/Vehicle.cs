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
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int CostCentreID { get; set; }
        public int BranchID { get; set; }
        public string FixedAssetsNumber { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public Double AcquistionCost { get; set; }
        public Double DepreciationMonths { get; set; }
        
        [Required]
        [MaxLength(10)]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        public VehicleType VechileType { get; set; }
        public SubContractor SubContractor { get; set; }
        public CostCentre CostCentre { get; set; }
        public Branch Branch { get; set; }
        public Model Model { get; set; }
        public Make Make {get;set;}
    }
}
