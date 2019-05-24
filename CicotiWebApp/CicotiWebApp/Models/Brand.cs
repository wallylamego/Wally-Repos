using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Description { get; set; }
        public int PrincipleID { get; set; }
        public Principle Principle { get; set; }
    }
}
