using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class VehicleComment
    {
        public int VehicleCommentID { get; set; }
        public string Comment { get; set; }
        public string UserID { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }

        public int VehicleID { get; set; }

        public Vehicle Vehicle { get; set; }
        public ApplicationUser User { get; set; }
    }
}
