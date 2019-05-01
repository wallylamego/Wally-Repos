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
        public int ? SubContractorID { get; set; }
        public int ? VehiclePurposeID { get; set; }
        public int ? ModelID { get; set; }
        public int ? CostCentreID { get; set; }
        public int ? BranchID { get; set; }
        public int ? VehicleStatusID { get; set;}

        public double? PayloadHeight { get; set; }
        public double? PayloadWidth { get; set; }
        public double? PayloadLength { get; set; }
        public double? PayloadCubicMetres { get; set; }
        [Required]
        public double litresPerHundredKms { get; set; }

        public string FixedAssetsNumber { get; set; }
        [Required]
        public DateTime AcquisitionDate { get; set; }
        [Required]
        public Double AcquistionCost { get; set; }
        public Double DepreciationMonths { get; set; }
        
        public int ? EmployeeID { get; set; }
        public int ? ActCostAllocationSplitID { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        public string RegNumberABB { get; set; }
        public VehiclePurpose VehiclePurpose { get; set; }
        public VehicleType VechileType { get; set; }
        public Employee Employee { get; set; }
        public SubContractor SubContractor { get; set; }
        public CostCentre CostCentre { get; set; }
        public Branch Branch { get; set; }
        public Model Model { get; set; }
        public VehicleStatus VehicleStatus { get; set; }

        public ActCostAllocationSplit ActCostAllocationSplit { get; set; }
    }
}
