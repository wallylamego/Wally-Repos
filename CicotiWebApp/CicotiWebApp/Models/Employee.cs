﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeNo { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int ReportsToID { get; set; }
        public int BranchID { get; set; }
        public int SaleRepID { get; set; }
        public int JobDescriptionID { get; set; }
        public int DepartmentID { get; set; }
        public int CostCentreID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String BankAccount { get; set; }
        public String PastelRepCode { get; set; }
        public String PastelRepName { get; set; }
        public JobDescription JobDescription { get; set; }
        public Department Department { get; set; }
        public CostCentre CostCentre { get; set; }
        public Branch Branch { get; set; }
    }
}
