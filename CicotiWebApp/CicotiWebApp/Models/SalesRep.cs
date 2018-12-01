using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class SalesRep: Employee
    {
        public int SalesRepID { get; set; }
        [Required]
        public String PastelRepCode { get; set; }
        [Required]
        public String PastelRepName { get; set; }
    }
}
