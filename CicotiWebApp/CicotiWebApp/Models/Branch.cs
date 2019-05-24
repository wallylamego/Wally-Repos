using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string ERPBranchID { get; set; }
        public string BranchName { get; set; }
        public int ? RegionID { get; set; }

        public Region Region { get; set; }
    }
}
