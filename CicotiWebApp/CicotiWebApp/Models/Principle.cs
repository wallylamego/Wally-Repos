using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Principle
    {
        public int PrincipleID { get; set; }
        [Required]
        public String PrincipalName { get; set; }
        [Required]
        public String PastelName{ get; set; }
        public int? SiloID { get; set; }
        public Silo Silo { get; set; }
        public int SortOrder { get; set; }
        public Boolean Active { get; set; }
        public int ? MainPrincipleID { get; set; }
        public double ? GPPercentage { get; set; }

        [ForeignKey(nameof(MainPrincipleID))]
        public Principle MainPrinciple { get; set; }

    }
}
