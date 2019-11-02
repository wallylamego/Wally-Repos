using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public int WarehouseTypeID { get; set; }
        public int BranchID { get; set; }
        public int ? PastelWarehouseID {get;set;}
        public string WarehouseName { get; set; }

        public WarehouseType WarehouseType { get; set; }
        public Branch Branch { get; set; }
    }
}
