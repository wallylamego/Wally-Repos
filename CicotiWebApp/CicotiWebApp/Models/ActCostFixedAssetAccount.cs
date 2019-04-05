using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostFixedAssetAccount
    {
        public int ActCostFixedAssetAccountID { get; set; }
        public int ActCostFixedAssetCostAccountID { get; set; }
        public int ActCostFixedAssetAccDepAccountID { get; set; }
        public int ActCostFixedAssetDepAccountID { get; set; }

        [ForeignKey(nameof(ActCostFixedAssetCostAccountID))]
        public ActCostAccount FixedAssetCostAccount { get; set; }
        [ForeignKey(nameof(ActCostFixedAssetAccDepAccountID))]
        public ActCostAccount FixedAssetAccDepAccount { get; set; }
        [ForeignKey(nameof(ActCostFixedAssetDepAccountID))]
        public ActCostAccount FixedAssetDepAccount { get; set; }
    }
}
