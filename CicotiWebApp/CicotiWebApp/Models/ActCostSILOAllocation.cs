using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostSiloAllocation
    {
        public int ActCostSiloAllocationID { get; set; }
        public int ActCostAllocationSplitID { get; set; }
        public int SiloID { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeID { get; set; }

        public int ActCostPeriodID { get; set; }
        public double AllocPercentage { get; set; }
        public String Description { get; set; }
        public String Comments { get; set; }

        public Silo Silo { get; set; }
        public Employee Employee {get;set;}
        public ActCostAllocationSplit ActCostAllocationSplit { get; set; }
        public ActCostPeriod ActCostPeriod { get; set; }

    }
}
