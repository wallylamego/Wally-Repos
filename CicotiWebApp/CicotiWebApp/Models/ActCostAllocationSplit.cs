using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostAllocationSplit
    {
        public int ActCostAllocationSplitID { get; set; }
        public string Description { get; set; }
        public Boolean ? SiloOnly { get; set; }
        public int ? SiloID { get; set; }
        public Silo Silo { get; set; }
}
}
