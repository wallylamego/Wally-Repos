using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class InvoiceStatusTrail
    {
        public int InvoiceStatusTrailID { get; set;}
        public int InvoiceID { get; set; }
        public int StatusID { get; set; }
        public int CreatedDate { get; set; }
        public string UserID { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }

        public ApplicationUser User { get; set; }

    }
}
