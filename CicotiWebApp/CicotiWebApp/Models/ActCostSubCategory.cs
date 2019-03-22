using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class ActCostSubCategory
    {
        public int ActCostSubCategoryID { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int ActCostCategoryID { get; set; }

        public ActCostCategory ActCostCategory { get;set;}
    }
}
