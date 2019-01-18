using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class InvoiceStatus
    {
        public int InvoiceStatusID { get; set;}
        public int InvoiceID { get; set; }
        public int StatusID { get; set; }
        public string UserID { get; set; }

        public int ? LoadID { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }

        public ApplicationUser User { get; set; }

        public Invoice Invoice { get; set; }
        public Status Status { get; set; }
        public Load Load { get; set; }
    }
}
