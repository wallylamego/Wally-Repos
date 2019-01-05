using System;
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

        public int JobDescriptionID { get; set; }
        
        public JobDescription JobDescription { get; set; }
    }
}
