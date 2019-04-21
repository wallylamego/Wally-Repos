using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostWarehouse
    {
        public int ActCostWarehouseID { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public int BranchID { get; set; }
        public int ActCostChannelID { get; set; }

        public Branch Branch { get; set; }
        public ActCostChannel ActCostChannel { get;set;}
    }
}
