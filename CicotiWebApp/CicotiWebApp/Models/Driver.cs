using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Driver
    {
        public int DriverID { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Cell Phone Number")]
        public string CellNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "PDP Expiry Date")]
        public DateTime PDPExpiryDate { get; set; }

        [Display(Name = "ID / Passport No")]
        [MaxLength(20)]
        public string IDNumber { get; set; }

        public int SubContractorID { get; set; }
        public int ? EmployeeID { get; set; }

        public Employee Employee { get; set; }
        public SubContractor SubContractor { get; set; }

    }
}
