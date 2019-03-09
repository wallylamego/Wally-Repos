using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Load
    {
        public int LoadID { get; set; }
        public string LoadName { get; set; }
        public string LoadDate { get; set; }
       
        public int VehicleID { get; set; }
        public int DriverID { get; set; }
        public string UserID { get; set; }

        public int ? LoadStatusID { get; set; }

        public Boolean ReverseDestinationID { get; set; }

        public int ?  DestinationID { get; set; }

        public Destination Destination { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }

        public Driver Driver { get; set; }  
        public List<Invoice> Invoices { get; set; }
        public ApplicationUser User { get; set; }
        public Vehicle Vehicle { get; set; }
        public LoadStatus LoadStatus { get; set; }
    }
}
