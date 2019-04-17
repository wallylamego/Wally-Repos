using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class CopyFromToPeriod
    {
        public ActCostPeriod CopyFromPeriod { get; set; }
        public ActCostPeriod CopyToPeriod { get; set; }
    }
}
